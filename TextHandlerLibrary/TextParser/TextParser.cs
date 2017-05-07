using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.TextParser
{
    public class TextParser
    {
        private string[] sentenceSeparators = { ".", "!", "...", "!?", "?!" };
        private char[] sentenceSeparatorsLight = { '.', '!', '?' };
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

        public TextParser()
        { }

        public void Parse(string path)
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
                string sentenceSeparartor = GetSentenceSeparator(ref separatorIndex, buffer_1.ToString());
                if (sentenceSeparartor != null)
                {
                    #region Create sentece
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
                    if (buffer_1.ToString().IndexOfAny(sentenceSeparatorsLight) == -1)
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
        private string GetSentenceSeparator(ref int separatorIndex, string s_buffer)
        {
            Dictionary<int, string> separatorIndexes = new Dictionary<int, string>();

            foreach (string separator in sentenceSeparators)
            {
                separatorIndex = s_buffer.IndexOf(separator);
                if (separatorIndex !=-1)
                    separatorIndexes[separatorIndex]= separator;
            }

            if (separatorIndexes.Count != 0)
            {
                separatorIndex = separatorIndexes.Keys.Min();
                return s_buffer.Substring(separatorIndex, separatorIndexes[separatorIndex].Length);
            }    
            else
            {
                return null;
            }
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
    }
}
