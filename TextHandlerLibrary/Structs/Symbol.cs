using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.Structs
{
    public struct Symbol
    {
        private string symbol;

        public Symbol(char symbol)
        {
            this.symbol = symbol.ToString();
        }
    }
}
