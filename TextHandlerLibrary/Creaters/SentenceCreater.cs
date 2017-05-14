using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.CreatersInterfaces;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.TextItemsClasses;

namespace TextHandlerLibrary.Creaters
{
    public class SentenceCreater: ITextItemCreator
    {
        private IList<ISentenceItem> _sentenceItems;

        public IList<ISentenceItem> SentenceItems
        {
            get
            {
                return new List<ISentenceItem>(_sentenceItems);
            }
        }

        public SentenceCreater()
        {
            _sentenceItems = new List<ISentenceItem>();
        }

        public void Add(ISentenceItem sentenceItem)
        {
            if (sentenceItem != null)
                _sentenceItems.Add(sentenceItem);
        }
        public ISentence Create()
        {
            if (_sentenceItems.Count != 0)
                return new Sentence(SentenceItems);
            else
                return null;
        }
        public void Clear()
        {
            _sentenceItems.Clear();
        }
    }
}
