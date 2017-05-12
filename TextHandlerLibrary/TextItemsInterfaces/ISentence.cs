using System.Collections.Generic;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    public interface ISentence: IEnumerable<ISentenceItem>
    {
        ISentenceItem this[int index] { get; }
        int Count { get; }
        int WordCount { get; }
        string SentenceToString { get; }
        bool Interrogative { get; }
        IEnumerable<IWord> Words { get; }
        IList<ISentenceItem> SentenceItems { get; }

        void Add(ISentenceItem item);
        void Remove(ISentenceItem item);
        void RemoveAtIndex(int index);
        void InsertSentenceItemsByIndex(int index, ICollection<ISentenceItem> _sentenceItems);
    }
}
