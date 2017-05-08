using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolContainers
{
    public class SymbolContainer
    {
        private char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        private char[] coconsonants = {'b', 'c', 'd', 'f', 'g', 'h',
                                  'j', 'k', 'l', 'm', 'n', 'p',
                                  'r', 's', 't', 'v', 'w', 'x', 'z', '-'};
        private char[] wordSeparators = { ' ', ',', ';', ':', '.', '—' };
        private string[] sentenceSeparators = { ".", "!", "...", "!?", "?!" };

        public char[] Vowels
        {
            get
            {
                return vowels;
            }
        }
        public char[] Coconsonants
        {
            get
            {
                return coconsonants;
            }
        }
        public char[] WordSeparators
        {
            get
            {
                return wordSeparators;
            }
        }
        public string[] SentenceSeparators
        {
            get
            {
                return sentenceSeparators;
            }
        }


    }
}
