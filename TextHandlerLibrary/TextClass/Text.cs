using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<IWord> GetWordsByLengthInInterrogative(int length)
        {
            var words = sentences.
                Where(x => x.Interrogative).
                SelectMany(y => y.Words).
                Where(z => z.Length == length).
                Distinct();

            if (words.Count() != 0)
                return words;
            else
                return null;
        }
        public void DeleteWordsByLength(int length)
        {
            var _words = sentences.SelectMany(x => x.Words).ToArray().
                Where(x =>x.Length == length && x[0].IsVowel == false).Distinct();

            for (int i=0; i< sentences.Count; i++)
            {
                ISentence sentence = sentences.ToList()[i];
                foreach (ISentenceItem word in _words)
                {
                    while (sentence.Contains(word))
                    {
                        int spaceIndex = sentence.ToList().IndexOf(word) - 1;
                        sentence.Remove(word);
                        sentence.RemoveAtIndex(spaceIndex);
                    }
                }
            }
        }

    }
}
