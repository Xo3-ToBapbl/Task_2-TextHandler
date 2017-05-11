using System.Collections.Generic;
using System.Linq;
using TextHandlerLibrary.CreatersInterfaces;
using TextHandlerLibrary.SenstenseItemsClasses;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.Structs;
using TextHandlerLibrary.SymbolContainers;

namespace TextHandlerLibrary.Creaters
{
    public class WordCreater: ISentenceItemCreator
    {
        private SymbolContainer symbolContainer;

        public WordCreater(SymbolContainer symbolContainer)
        {
            this.symbolContainer = symbolContainer;
        }

        public ISentenceItem Create(string chars)
        {
            ICollection <Symbol> symbols = new List<Symbol>(); // mistake
            foreach (char _char in chars)
            {
                if(symbolContainer.Vowels.Any(x=>x == char.ToLower(_char) ))
                {
                    Symbol symbol = new Symbol(_char, true);
                    symbols.Add(symbol);
                }
                if (symbolContainer.Coconsonants.Any(x => x == char.ToLower(_char)))
                {
                    Symbol symbol = new Symbol(_char);
                    symbols.Add(symbol);
                }
            }
            if (symbols.Count != 0)
                return new Word(symbols);
            else
                return null;     
        }
    }
}
