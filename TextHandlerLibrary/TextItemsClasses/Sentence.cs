using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.TextItemsClasses
{
    public  class Sentence : ISentence
    {
        private ICollection<ISentenceItem> sentenceItems;

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
                return sentenceItems.Where(x => x is IWord).Count();
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
                return sentenceItems.Any(x => x.Chars == "?");
            }
        }
        public IEnumerable<IWord> Words
        {
            get
            {
                return sentenceItems.Where(x => x is IWord).Cast<IWord>();
            }
        }
        public ICollection<ISentenceItem> SentenceItems
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
                return sentenceItems.ToArray()[index];
            }
        }

        public Sentence(ICollection <ISentenceItem> sentenceItems)
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
