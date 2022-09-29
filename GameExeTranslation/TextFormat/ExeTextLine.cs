using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExeTranslation.TextFormat
{
    public class ExeTextLine
    {
        private long offset;
        private long tempOffset;
        private string translatedText, originalText;
        private bool isFullWidth = true;
        private string originalSector = ".rdata";

        public ExeTextLine()
        {
        }

        public ExeTextLine(long pointer, string translatedText, string originalText)
        {
            this.offset = pointer;
            this.translatedText = translatedText;
            this.originalText = originalText;
        }

        public long Offset { get => offset; set => offset = value; }
        public string TranslatedText { get => translatedText; set => translatedText = value; }
        public string OriginalText { get => originalText; set => originalText = value; }
        [JsonIgnore, Browsable(false)]
        public long TempOffset { get => tempOffset; set => tempOffset = value; }
        public bool IsFullWidth { get => isFullWidth; set => isFullWidth = value; }
        public string OriginalSector { get => originalSector; set => originalSector = value; }
    }
}
