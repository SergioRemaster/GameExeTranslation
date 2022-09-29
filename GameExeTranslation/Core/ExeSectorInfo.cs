using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExeTranslation.Core
{
    public class ExeSectorInfo
    {
        private string name;
        private uint vOffset, vSize, rOffset, rSize, flags;

        public ExeSectorInfo()
        {
        }

        public ExeSectorInfo(string name, uint vSize, uint vOffset, uint rSize, uint rOffset)
        {
            this.name = name;
            this.vOffset = vOffset;
            this.vSize = vSize;
            this.rOffset = rOffset;
            this.rSize = rSize;
        }

        public string Name { get => name; set => name = value; }
        public uint VOffset { get => vOffset; set => vOffset = value; }
        public uint VSize { get => vSize; set => vSize = value; }
        public uint ROffset { get => rOffset; set => rOffset = value; }
        public uint RSize { get => rSize; set => rSize = value; }
        public uint Flags { get => flags; set => flags = value; }

        public override string ToString()
        {
            return name;
        }
    }
}
