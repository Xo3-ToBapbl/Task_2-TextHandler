using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    public interface IWord: ISentenceItem, IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
        int Length { get; }
        bool Equals(IWord word);
    }
}
