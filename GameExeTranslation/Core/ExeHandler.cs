using GameExeTranslation.TextFormat;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameExeTranslation.Core
{
    public class ExeHandler
    {
        private int exeHeaderPosition, sectorListPosition, emptySectorPosition;
        private uint imageSize, imageBase;
        private short sectorsNumber;
        private string exePath = "";
        private List<ExeSectorInfo> sectorInfoList = new List<ExeSectorInfo>();
        private const uint VIRTUAL_ADDRESS_CONST = 4096;


        public string ExePath { get => exePath; set => exePath = value; }
        public List<ExeSectorInfo> SectorInfoList { get => sectorInfoList; set => sectorInfoList = value; }

        public void GetExeInfo()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(exePath, FileMode.Open)))
            {
                reader.BaseStream.Seek(60, SeekOrigin.Begin);
                exeHeaderPosition = reader.ReadInt32();
                reader.BaseStream.Seek(exeHeaderPosition + 6, SeekOrigin.Begin);
                sectorsNumber = reader.ReadInt16();
                reader.BaseStream.Seek(exeHeaderPosition + 52, SeekOrigin.Begin);
                imageBase = reader.ReadUInt32();
                reader.BaseStream.Seek(exeHeaderPosition + 80, SeekOrigin.Begin);
                imageSize = reader.ReadUInt32();
                reader.BaseStream.Seek(exeHeaderPosition + 248, SeekOrigin.Begin);
                sectorListPosition = (int)reader.BaseStream.Position;
                for (int x = 0; x < sectorsNumber; ++x)
                {
                    ExeSectorInfo exeSectorInfo = new ExeSectorInfo(
                        Encoding.ASCII.GetString(reader.ReadBytes(8)).Replace("\0",""),
                        reader.ReadUInt32(),
                        reader.ReadUInt32(),
                        reader.ReadUInt32(),
                        reader.ReadUInt32());
                    reader.BaseStream.Seek(12, SeekOrigin.Current);
                    exeSectorInfo.Flags = reader.ReadUInt32();
                    sectorInfoList.Add(exeSectorInfo);
                }
                emptySectorPosition = (int)reader.BaseStream.Position;
            }   
        }

        public void SaveTranslatedExe(List<ExeSectorText> exeSectorTextList)
        {
            byte[] file = File.ReadAllBytes(exePath);
            List<ExeSectorInfo> newSectorInfoList = new List<ExeSectorInfo>();
            ExeSectorInfo prevExeSectorInfo = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    //Copy exe content
                    writer.Write(file);

                    //Write translated text for all writable sectors, and set writable sectors info
                    foreach (ExeSectorText sector in exeSectorTextList)
                    {
                        ExeSectorInfo newSector = new ExeSectorInfo();
                        newSector.Name = sector.Name;
                        newSector.ROffset = (uint)writer.BaseStream.Position;

                        foreach (ExeTextLine text in sector.TextList)
                        {
                            text.TempOffset = writer.BaseStream.Position;
                            if (text.IsFullWidth)
                                writer.Write(Encoding.GetEncoding("shift_jis").GetBytes(CharWidthConverter.DBCToSBC(text.TranslatedText)));
                            else
                                writer.Write(Encoding.GetEncoding("shift_jis").GetBytes(CharWidthConverter.SBCToDBC(text.TranslatedText)));
                            writer.Write((byte)0);
                        }

                        if (prevExeSectorInfo == null)
                            newSector.VOffset = CalculateVOffset(sectorInfoList.Last().VSize, sectorInfoList.Last().VOffset);
                        else
                            newSector.VOffset = CalculateVOffset(prevExeSectorInfo.VSize, prevExeSectorInfo.VOffset);

                        newSector.RSize = (uint)writer.BaseStream.Position - newSector.ROffset;
                        while (newSector.RSize % VIRTUAL_ADDRESS_CONST != 0)
                        {
                            writer.Write((byte)0);
                            newSector.RSize++;
                        }
                        newSector.VSize = newSector.RSize;
                        newSector.Flags = 0x40000040;
                        prevExeSectorInfo = newSector;
                        newSectorInfoList.Add(newSector);
                    }

                    //Write new sectors related data
                    writer.BaseStream.Seek(exeHeaderPosition + 6, SeekOrigin.Begin);
                    writer.Write((short)(sectorsNumber + (short)exeSectorTextList.Count));
                    writer.BaseStream.Seek(exeHeaderPosition + 80, SeekOrigin.Begin);
                    uint newImageSize = imageSize;
                    newSectorInfoList.ForEach(p => newImageSize += p.RSize);
                    writer.Write(newImageSize);
                    writer.BaseStream.Seek(emptySectorPosition, SeekOrigin.Begin);
                    foreach (ExeSectorInfo sector in newSectorInfoList)
                    {
                        string nameTemp = sector.Name;
                        while (nameTemp.Length < 8)
                            nameTemp += "\0";
                        writer.Write(Encoding.ASCII.GetBytes(nameTemp));
                        writer.Write(sector.VSize);
                        writer.Write(sector.VOffset);
                        writer.Write(sector.RSize);
                        writer.Write(sector.ROffset);
                        writer.Write((long)0);
                        writer.Write(0);
                        writer.Write(sector.Flags);
                    }

                    //Replace original text pointers with the new ones
                    ExeSectorInfo readSectorInfo = null;
                    uint readableSectorValue = 0;
                    foreach (ExeSectorText sector in exeSectorTextList)
                    {
                        ExeSectorInfo writableSectorInfo = newSectorInfoList.Find(p => p.Name == sector.Name);
                        uint writableSectorValue = imageBase + writableSectorInfo.VOffset - writableSectorInfo.ROffset;
                        foreach (ExeTextLine text in sector.TextList)
                        {
                            if (readSectorInfo == null || readSectorInfo.Name != text.OriginalSector)
                            {
                                readSectorInfo = sectorInfoList.Find(p => p.Name == text.OriginalSector);
                                readableSectorValue = imageBase + readSectorInfo.VOffset - readSectorInfo.ROffset;
                            }
                            uint oldPointer = (uint)(text.Offset + readableSectorValue);
                            uint newPointer = (uint)(text.TempOffset + writableSectorValue);

                            //Replace pointer inside desired sectors
                            foreach (string searchSector in sector.SearchSectorList)
                            {
                                ExeSectorInfo searchSectorInfo = sectorInfoList.Find(p => p.Name == searchSector);
                                ReplaceBytes(ms, writer, searchSectorInfo.ROffset, searchSectorInfo.RSize + searchSectorInfo.ROffset,
                                    oldPointer, newPointer);
                            }
                        }
                    }

                    //Write stream in new exe file
                    using (FileStream fs = new FileStream(Directory.GetParent(exePath).FullName + "\\"+
                        Path.GetFileNameWithoutExtension(exePath) + "_translated.exe", FileMode.Create, FileAccess.Write))
                    {
                        ms.WriteTo(fs);
                    }
                }
            }
        }

        private uint CalculateVOffset(uint previousVSize, uint previousVOffset)
        {
            uint value = previousVSize + previousVOffset;
            if (value % VIRTUAL_ADDRESS_CONST != 0)
            {
                value += VIRTUAL_ADDRESS_CONST - (value % VIRTUAL_ADDRESS_CONST);
            }
            return value;
        }

        private void ReplaceBytes(MemoryStream ms, BinaryWriter writer, uint startPosition, uint endPosition, uint targetValue, uint newValue)
        {
            List<uint> replacePositions = new List<uint>();
            using (MemoryStream ms2 = new MemoryStream(ms.ToArray()))
            {
                using (BinaryReader reader = new BinaryReader(ms2))
                {
                    reader.BaseStream.Seek(startPosition, SeekOrigin.Begin);
                    for (uint x = startPosition; x < endPosition - 3; ++x)
                    {
                        if (reader.ReadUInt32() == targetValue)
                            replacePositions.Add((uint)reader.BaseStream.Position - 4);
                        reader.BaseStream.Seek(-3, SeekOrigin.Current);
                    }
                }
            }

            foreach (uint position in replacePositions)
            {
                writer.BaseStream.Seek(position, SeekOrigin.Begin);
                writer.Write(newValue);
            }
        }
    }
}
