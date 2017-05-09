using System;
using System.Linq;
using System.Xml.Linq;

namespace TextHandlerLibrary.SymbolContainers
{
    public class SymbolContainer
    {
        #region Symbols
        //private char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        //private char[] coconsonants = {'b', 'c', 'd', 'f', 'g', 'h',
        //                          'j', 'k', 'l', 'm', 'n', 'p',
        //                          'r', 's', 't', 'v', 'w', 'x', 'z', '-'};
        //private char[] wordSeparators = { ' ', ',', ';', ':', '.', '—', '!', '?' };
        //private string[] sentenceSeparators = { ".", "!", "?", "!?", "?!", "..." };
        #endregion
        private char[] vowels;
        private char[] coconsonants;
        private char[] wordSeparators;
        private string[] sentenceSeparators;

        public SymbolContainer(string path)
        {
            XDocument symbolsXdoc = XDocument.Load(path);
            string symbols = symbolsXdoc.Element("Symbols").Element("vowels").Value;
            vowels = symbols.Split(' ').Select(x => Convert.ToChar(x)).ToArray();

            symbols = symbolsXdoc.Element("Symbols").Element("coconsonants").Value;
            coconsonants = symbols.Split(' ').Select(x => Convert.ToChar(x)).ToArray();

            symbols = symbolsXdoc.Element("Symbols").Element("wordSeparators").Value;
            var _wordSeparators = symbols.Split(' ').ToList();
            _wordSeparators.Add(" ");
            wordSeparators = _wordSeparators.Select(x => Convert.ToChar(x)).ToArray();

            symbols = symbolsXdoc.Element("Symbols").Element("sentenceSeparators").Value;
            sentenceSeparators = symbols.Split(' ');
        }

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
