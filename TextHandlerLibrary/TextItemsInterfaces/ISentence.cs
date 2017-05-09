using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    public interface ISentence: IEnumerable<ISentenceItem>
    {
        ISentenceItem this[int index] { get; }
        void Add(ISentenceItem item);
        void Remove(ISentenceItem item);
        void RemoveAtIndex(int index);
        int Count { get; }
        int WordCount { get; }
        string SentenceToString { get; }
        bool Interrogative { get; }
        IEnumerable<IWord> Words { get; }
        ICollection<ISentenceItem> SentenceItems { get; }
    }
}
