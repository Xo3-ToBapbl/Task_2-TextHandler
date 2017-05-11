using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsClasses
{
    public class Space : ISpace
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

        public Space(Symbol source)
        {
            value = source;
        }
    }
}
