using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.Structs
{
    public struct Symbol
    {
        private string chars;
        private bool isVowel;

        public bool IsVowel
        {
            get
            {
                return isVowel;
            }
        }
        public string Chars
        {
            get
            {
                return chars;
            }
        }

        public Symbol(string chars, bool isVowel)
        {
            this.chars = chars;
            this.isVowel = isVowel;
        }
        public Symbol(char _char, bool isVowel)
        {
            this.chars = _char.ToString();
            this.isVowel = isVowel;
        }
        public Symbol(char _char)
        {
            this.chars = _char.ToString();
            this.isVowel = false;
        }
    }
}
