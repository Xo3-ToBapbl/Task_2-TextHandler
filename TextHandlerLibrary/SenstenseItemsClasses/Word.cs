using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsClasses
{
    public class Word
    {
        private Symbol[] symbols; 

        public Symbol this[int index]
        {
            get
            {
                return symbols[index];
            }
        }

        public Word(string chars)
        {
            if (chars != null)
            {
                symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
        }
    }
}
