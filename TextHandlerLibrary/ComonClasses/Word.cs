﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextHandlerLibrary.Interfaces;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsClasses
{
    public class Word: IWord
    {
        private Symbol[] symbols;

        public int Length
        {
            get
            {
                return (symbols != null) ? symbols.Length: 0;
            }
        }
        public string Chars
        {
            get
            {
                StringBuilder _chars = new StringBuilder();
                foreach (var s in this.symbols)
                {
                    _chars.Append(s.Chars);
                }
                return _chars.ToString();
            }
        }
        public Symbol this[int index]
        {
            get
            {
                return symbols[index];
            }
        }

        public Word(IEnumerable<Symbol> source)
        {
            symbols = source.ToArray();
        }

        public IEnumerator<Symbol> GetEnumerator()
        {
            return symbols.AsEnumerable().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return symbols.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            IWord word = obj as IWord;
            if (word == null)
                return false;
            else
            {
                if (this.Chars.ToLower() == word.Chars.ToLower())
                    return true;
                else
                    return false;
            }
        }
        public override int GetHashCode()
        {
            return this.Chars.ToLower().GetHashCode();
        }
    }
}
