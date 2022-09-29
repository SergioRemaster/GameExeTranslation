using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExeTranslation.TextFormat
{
    /// <summary> mutual conversion of full-width half-width
    /// 
    /// </summary>
    public static class CharWidthConverter
    {

        /// <summary> half-width turned into full-width
        /// Half-width space 32, full-width space 12288
        /// Other characters are half-width 33~126, other characters are full-width 65281~65374, the difference is 65248
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DBCToSBC(string input)
        {
            char[] cc = input.ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] == 32)
                {
                    // indicates a space
                    cc[i] = (char)12288;
                    continue;
                }
                if (cc[i] < 127 && cc[i] > 32)
                {
                    cc[i] = (char)(cc[i] + 65248);
                }
            }
            return new string(cc);
        }

        /// <summary> full-width half-width
        /// Half-width space 32, full-width space 12288
        /// Other characters are half-width 33~126, other characters are full-width 65281~65374, the difference is 65248
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SBCToDBC(string input)
        {
            char[] cc = input.ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] == 12288)
                {
                    // indicates a space
                    cc[i] = (char)32;
                    continue;
                }
                if (cc[i] > 65280 && cc[i] < 65375)
                {
                    cc[i] = (char)(cc[i] - 65248);
                }

            }
            return new string(cc);
        }
    }
}
