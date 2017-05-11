using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsClasses
{
    class Punctuation: IPunctuation
    {
        private Symbol value;

        public Symbol Value
        {
            get
            {
                return this.value;
            }
        }
        public string Chars
        {
            get
            {
                return this.Value.Chars;
            }
        }
        public int Length
        {
            get
            {
                return this.Chars.Length;
            }
        }

        public Punctuation(Symbol source)
        {
            value = source;
        }
    }
}
