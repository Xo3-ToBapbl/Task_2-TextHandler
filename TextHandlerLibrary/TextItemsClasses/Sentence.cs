using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.TextItemsClasses
{
    class Sentence : ISentence
    {
        private ICollection<ISentenceItem> sentenceItems;

        public Sentence(ICollection <ISentenceItem> sentenceItems)
        {
            this.sentenceItems = sentenceItems;
        }

        public int WordCount
        {
            get
            {
                return sentenceItems.Select(x => x is IWord).Count();
            }
        }

        public void Add(ISentenceItem item)
        {
            sentenceItems.Add(item);
        }
        public void Remove(ISentenceItem item)
        {
           sentenceItems.Remove(item);
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
