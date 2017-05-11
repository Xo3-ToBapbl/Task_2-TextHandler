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
        public ISentence this[int index]
        {
            get
            {
                return sentences.ToArray()[index];
            }
        }

        public Text(ICollection<ISentence> sentecnces)
        {
            this.sentences = sentecnces;
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
        public void ReplaceWordsByLength(int sentenceIndex, int length, ISentence senteneItems)
        {
            ISentence sentence = this[sentenceIndex];
            if (senteneItems != null)
            {
                int startIndex = -1; int count = 0; int index;
                while (true)
                {
                    if ((startIndex + 1 + count) <= sentence.Count)
                    {
                        index = sentence.ToList().
                           FindIndex(startIndex + 1 + count, x => x.Length == length);
                    }
                    else
                    {
                        break;
                    }
                    startIndex = index;
                    count = senteneItems.Count;

                    if (startIndex != -1)
                    {
                        sentence.RemoveAtIndex(index - 1);
                        sentence.RemoveAtIndex(index - 1);
                        sentence.InsertSentenceItemsByIndex(index - 1, senteneItems.SentenceItems);
                    }
                    else
                    {
                        break;
                    } 

                    
                }
            }
            
        }



    }
}
