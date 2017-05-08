using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    interface ISpace: ISentenceItem
    {
        Symbol Value { get; }
    }
}
