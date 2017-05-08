using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.SymbolContainers;
using TextHandlerLibrary.TextItemsClasses;

namespace TextHandlerLibrary.TextParser
{
    public class TextParser
    {
        private string[] sentenceSeparators = { ".", "!", "...", "!?", "?!" };
        private SymbolContainer symbolContainer;
        private List<string> sentences = new List<string>();

        public List<string> Sentences
        {
            get
            {
                return sentences;
            }
            set
            {
                sentences = value;
            }
        }

        public TextParser(SymbolContainer symbolContainer)
        {
            this.symbolContainer = symbolContainer;
        }

        #region Text parser
        public void SentencesParser(string path)
        {
            #region Source
            StreamReader textStream = new StreamReader(path);
            StringBuilder buffer_1 = new StringBuilder(10000);
            StringBuilder buffer_2 = new StringBuilder(10000);
            buffer_1.Clear(); buffer_2.Clear();

            string currentString = textStream.ReadLine();
            buffer_1.Append(currentString);

            int separatorIndex = -1;
            #endregion
            while (currentString != null)
            {
                string sentenceSeparartor = GetSentenceSeparator(
                    ref separatorIndex, buffer_1.ToString(), symbolContainer.SentenceSeparators);
                if (sentenceSeparartor != null)
                {
                    #region Create Text
                    string sentence = buffer_2 + buffer_1.ToString().
                        Substring(0, separatorIndex + sentenceSeparartor.Length);
                    Sentences.Add(sentence);
                    buffer_2.Clear();
                    buffer_2.Append(buffer_1);
                    buffer_1.Clear();
                    buffer_1.Append(buffer_2.ToString().
                        Substring(separatorIndex + sentenceSeparartor.Length, 
                                  buffer_2.Length - (separatorIndex + sentenceSeparartor.Length)));
                    buffer_2.Clear();
                    #endregion
                    if (CheckSeparator(buffer_1.ToString(), symbolContainer.SentenceSeparators)!= true)
                    {
                        NextString(ref buffer_1, ref buffer_2, ref currentString, ref textStream);
                    }  
                }
                else
                {
                    NextString(ref buffer_1, ref buffer_2, ref currentString, ref textStream);
                }
            }

            textStream.Close();
        }
        private string GetSentenceSeparator(ref int separatorIndex, string buffer_1, string[] sentenceSeparators)
        {
            Dictionary<int, string> separatorIndexes = new Dictionary<int, string>();

            foreach (string separator in sentenceSeparators)
            {
                separatorIndex = buffer_1.IndexOf(separator);
                if (separatorIndex !=-1)
                    separatorIndexes[separatorIndex]= separator;
            }

            if (separatorIndexes.Count != 0)
            {
                separatorIndex = separatorIndexes.Keys.Min();
                return separatorIndexes[separatorIndex];
            }    
            else
            {
                return null;
            }
        }
        private bool CheckSeparator(string buffer_1, string[] sentenceSeparators)
        {
            foreach (string separator in sentenceSeparators)
            {
                int separatorIndex = buffer_1.IndexOf(separator);
                if (separatorIndex != -1)
                {
                    return true;
                }
            }
            return false;
        }
        private void NextString(ref StringBuilder buffer_1, ref StringBuilder buffer_2, 
                                   ref string currentString, ref StreamReader textStream)
        {
            buffer_2.Append(buffer_1);
            buffer_2.Append(" ");
            buffer_1.Clear();
            currentString = textStream.ReadLine();
            buffer_1.Append(currentString);
        }
        #endregion
        #region Sentence parser
        public void SentenceItemParser(string stringSentence)
        {
            ISentence sentence = new Sentence(new List<ISentenceItem>());
            List<string> sentenceItems = new List<string>();
            int separatorIndex = -1;

            StringBuilder buffer_1 = new StringBuilder();
            StringBuilder buffer_2 = new StringBuilder();
            buffer_1.Append(stringSentence.Trim());

            while (buffer_1.Length !=0)
            {
                char wordSeparator = ' ';
                string word = GetSentenceItems(ref separatorIndex, ref wordSeparator,
                                               symbolContainer.WordSeparators, buffer_1.ToString());
                if (word != "")
                {
                    sentenceItems.Add(" ");
                    sentenceItems.Add(word.Trim());
                }
                if (wordSeparator != ' ')
                    sentenceItems.Add(wordSeparator.ToString());

                buffer_2.Append(buffer_1);
                buffer_1.Clear();
                buffer_1.Append(buffer_2.ToString().
                    Substring(separatorIndex + 1, buffer_2.Length - separatorIndex - 1).Trim());
                if (string.Compare(buffer_1.ToString(), buffer_2.ToString()) != 0)
                    buffer_2.Clear();
                else
                {
                    buffer_1.Clear(); buffer_2.Clear();
                }
            }
            if (sentenceItems.Count != 0)
                sentenceItems.RemoveAt(0);
        }
        public string GetSentenceItems(ref int separatorIndex, ref char wordSeparator, 
                                       char[] wordSeparators, string buffer_1)
        {
            Dictionary<int, char> separatorIndexes = new Dictionary<int, char>();
            foreach (char separator in wordSeparators)
            {
                separatorIndex = buffer_1.IndexOf(separator);
                if (separatorIndex != -1)
                {
                    separatorIndexes[separatorIndex] = separator;
                }
            }
            if (separatorIndexes.Count != 0)
            {
                separatorIndex = separatorIndexes.Keys.Min();
                wordSeparator = separatorIndexes[separatorIndex];
                return buffer_1.Substring(0, separatorIndex);
            }
            else
                return buffer_1;
        }
        #endregion
    }
}
