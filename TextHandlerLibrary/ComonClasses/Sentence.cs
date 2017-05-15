using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TextHandlerLibrary.Interfaces;

namespace TextHandlerLibrary.TextItemsClasses
{
    public  class Sentence : ISentence
    {
        private IList<ISentenceItem> sentenceItems;

        public int Count
        {
            get
            {
                return sentenceItems.Count;
            }
        }
        public int WordCount
        {
            get
            {
                return sentenceItems.Count(x => x is IWord);
            }
        }
        public string SentenceToString
        {
            get
            {
                return string.Join("", sentenceItems.Select(x => x.Chars) );
            }
        }
        public bool Interrogative
        {
            get
            {
                return sentenceItems.Any(x => x.Chars == "?" || x.Chars == "!?" || x.Chars == "?!");
            }
        }
        public IEnumerable<IWord> Words
        {
            get
            {
                return sentenceItems.OfType<IWord>();
            }
        }
        public IList<ISentenceItem> SentenceItems
        {
            get
            {
                return sentenceItems;
            }
        }
        public ISentenceItem this[int index]
        {
            get
            {
                return sentenceItems[index];
            }
        }

        public Sentence(IList<ISentenceItem> sentenceItems)
        {
            this.sentenceItems = sentenceItems;
        }    

        public void Add(ISentenceItem item)
        {
            sentenceItems.Add(item);
        }
        public void Remove(ISentenceItem item)
        {
           sentenceItems.Remove(item);
        }
        public void RemoveAtIndex(int index)
        {
            sentenceItems.Remove(this[index]);
        }
        public void InsertSentenceItemsByIndex(int index, ICollection<ISentenceItem> _sentenceItems)
        {
            var newSentenceItems = sentenceItems.ToList();
            newSentenceItems.InsertRange(index, _sentenceItems);
            sentenceItems = newSentenceItems;
        }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return sentenceItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return sentenceItems.GetEnumerator();
        }
    }
}
