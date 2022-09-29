using GameExeTranslation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExeTranslation.TextFormat
{
    public class ExeSectorText
    {
        private string name;
        private List<string> searchSectorList = new List<string>();
        private List<ExeTextLine> textList = new List<ExeTextLine>();

        public ExeSectorText(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public List<string> SearchSectorList { get => searchSectorList; set => searchSectorList = value; }
        public List<ExeTextLine> TextList { get => textList; set => textList = value; }

        public override string ToString()
        {
            return name;
        }
    }
}
