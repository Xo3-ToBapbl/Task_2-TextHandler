﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TextHandlerLibrary.Creaters;
using TextHandlerLibrary.Interfaces;
using TextHandlerLibrary.SenstenseItemsClasses;
using TextHandlerLibrary.Structs;
using TextHandlerLibrary.SymbolContainers;
using TextHandlerLibrary.TextClass;
using TextHandlerLibrary.CommonClasses;

namespace TextHandlerLibrary.TextParser
{
    public class TextParser
    {
        private SymbolContainer symbolContainer;
        private ISentenceItemCreator wordCreator;
        private ITextItemCreator sentenceCreator;

        public TextParser(SymbolContainer symbolContainer)
        {
            this.symbolContainer = symbolContainer;
            this.wordCreator = new WordCreater(symbolContainer);
            this.sentenceCreator = new SentenceCreater();
        }

        #region Parse text by sentences
        public Text ParseText(string path, IList<ISentence> sentenceCollection)
        {
            #region Source data
            Text text = new Text(sentenceCollection);
            StreamReader textStream = new StreamReader(path);
            StringBuilder buffer_1 = new StringBuilder();
            StringBuilder buffer_2 = new StringBuilder();           

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
                    text.Sentences.Add(ParseSentenceByItems(sentence));
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

            if (text.SentencesCount != 0)
                return text;
            else
                return null;
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
        #region Parse sentence by sentence items
        public ISentence ParseSentenceByItems(string stringSentence)
        {
            int separatorIndex = -1;
            StringBuilder buffer_1 = new StringBuilder();
            StringBuilder buffer_2 = new StringBuilder();
            buffer_1.Append(stringSentence.Trim());

            while (buffer_1.Length !=0)
            {
                string wordSeparator = " ";
                string word = GetSentenceItems(ref separatorIndex, ref wordSeparator,
                                               symbolContainer.AllSeparators, buffer_1.ToString());
                if (word != "")
                {
                    sentenceCreator.Add(new Space(new Symbol(' ')) );
                    sentenceCreator.Add(wordCreator.Create(word));
                }
                if (wordSeparator != " ")
                    sentenceCreator.Add(new Punctuation(new Symbol(wordSeparator)));

                buffer_2.Append(buffer_1);
                buffer_1.Clear();
                buffer_1.Append(buffer_2.ToString().
                    Substring(
                    separatorIndex + wordSeparator.Length, buffer_2.Length - separatorIndex - wordSeparator.Length).
                    Trim());
                if (string.Compare(buffer_1.ToString(), buffer_2.ToString()) != 0)
                    buffer_2.Clear();
                else
                {
                    buffer_1.Clear(); buffer_2.Clear();
                }
            }
            ISentence sentence = sentenceCreator.Create();
            sentenceCreator.Clear();
            return sentence;
        }

        public string GetSentenceItems(ref int separatorIndex, ref string wordSeparator, 
                                       string[] allSeparators, string buffer_1)
        {
            Dictionary<int, string> separatorIndexes = new Dictionary<int, string>();
            foreach (string separator in allSeparators)
            {
                separatorIndex = buffer_1.IndexOf(separator);
                if (separatorIndex != -1)
                {
                    if (separatorIndexes.ContainsKey(separatorIndex) == false)
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
