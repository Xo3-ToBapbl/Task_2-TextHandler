using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using TextHandlerLibrary.TextParser;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.SymbolContainers;
using TextHandlerLibrary.TextClass;
using TextHandlerLibrary.TextItemsClasses;

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

            Text text = textParser.ParseText(textFilePath, new List<ISentence>());

            #region Tasks:
            // Returns text ordered by increase count of words in sentences:
            IOrderedEnumerable<ISentence> orderedText = text.GetSentenceOrderedByWordsCount();

            // Returns words with determine length in interrogative sentences:
            IEnumerable<IWord> words = text.GetWordsByLengthInInterrogative(3);

            // Delete all words with determine length from text which starts with coconsonants letters:
            text.DeleteWordsByLength(3);

            // In some sentence words with determine length replaced others sentence items:
            ISentence sentenceItems = textParser.ParseSentenceByItems("insert, this and  this   :");
            text.ReplaceWordsByLength(1, 2, sentenceItems);
            #endregion
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
