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
            #region source
            StreamReader textStream = new StreamReader(path);
            StringBuilder buffer = new StringBuilder(10000);
            StringBuilder s_buffer = new StringBuilder(10000);
            buffer.Clear(); s_buffer.Clear();

            string currentString = textStream.ReadLine();
            s_buffer.Append(currentString);

            int separatorIndex = -1;
            #endregion
            while (currentString != null)
            {
                string sentenceSeparartor = GetSentenceSeparator(ref separatorIndex, s_buffer.ToString());
                if (sentenceSeparartor != null)
                {
                    buffer.Append(s_buffer.ToString().Substring(0, separatorIndex + sentenceSeparartor.Length));
                    Sentences.Add(buffer.ToString());
                    buffer.Clear();
                    buffer.Append(currentString.
                        Substring(s_buffer.Length + 1, currentString.Length));
                    s_buffer.Clear();
                    if (GetSentenceSeparator(ref separatorIndex, buffer.ToString()) != null)
                    {
                        s_buffer = buffer;
                        buffer.Clear();
                    }
                    else
                    {
                        currentString = textStream.ReadLine();
                        s_buffer.Append(currentString);
                    }
                }
                else
                {

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
    }
}
