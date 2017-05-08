using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    public interface ISentence: IEnumerable<ISentenceItem>
    {
        void Add(ISentenceItem item);
        void Remove(ISentenceItem item);
        int WordCount { get; }
    }
}
