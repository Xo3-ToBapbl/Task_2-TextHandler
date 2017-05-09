using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using TextHandlerLibrary.TextParser;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.SymbolContainers;
using TextHandlerLibrary.TextClass;

namespace Demostration
{
    class Program
    {
        static void Main()
        {
            string textFilePath = ConfigurationManager.AppSettings["TextFilePath"];
            string symbolFilePath = ConfigurationManager.AppSettings["SymbolsFilePath"];

            SymbolContainer symbolContainer = new SymbolContainer(symbolFilePath);
            TextParser textParser = new TextParser(symbolContainer);

            Text text = textParser.ParseText(textFilePath);

            IOrderedEnumerable<ISentence> orderedText = text.GetSentenceOrderedByWordsCount();
            IEnumerable<IWord> words = text.GetWordsByLengthInInterrogative(3);
            text.DeleteWordsByLength(3);

            #region Words
            //Word word1 = new Word(new List<Symbol> { new Symbol('b', false), new Symbol('a', true), new Symbol('r', false) });
            //Word word2 = new Word(new List<Symbol> { new Symbol('B', false), new Symbol('A', true), new Symbol('r', false) });
            //Word word3 = new Word(new List<Symbol> { new Symbol('H', false), new Symbol('A', true), new Symbol('r', false) });
            //Word word4 = new Word(new List<Symbol> { new Symbol('H', false), new Symbol('A', true), new Symbol('r', false), new Symbol('T', false) });


            //bool res = word1.Equals(word3);
            //int hash1 = word1.GetHashCode();
            //int hash2 = word2.GetHashCode();
            //int hash3 = word3.GetHashCode();
            //int hash4 = word4.GetHashCode();
            #endregion
        }
    }
}
