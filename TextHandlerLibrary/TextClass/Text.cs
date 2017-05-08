using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.TextClass
{
    public class Text
    {
        private ICollection<ISentence> sentences;
        public ICollection<ISentence> Sentences
        {
            get
            {
                return sentences;
            }
        }
        public int SentencesCount
        {
            get
            {
                return Sentences.Count;
            }
        }

        public Text()
        {
            sentences = new List<ISentence>();
        }

        public IOrderedEnumerable<ISentence> GetSentenceOrderedByWordsCount()
        {
            return Sentences.OrderBy(x => x.WordCount);
        }
        public void DeleteWordsByLengthInInterrogative(int length)
        {

            var iterrogativeSentence = sentences.
                Where(x => x.Interrogative).
                SelectMany(y => y.Words).
                Where(z => z.Length == length).
                Distinct();
        }
    }
}
