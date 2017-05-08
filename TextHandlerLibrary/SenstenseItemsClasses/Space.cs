﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsClasses
{
    public class Space : ISpace
    {
        private Symbol value;

        public Symbol Value
        {
            get
            {
                return this.value;
            }
        }
        public string Chars
        {
            get
            {
                return this.Value.Chars;
            }
        }

        public Space(Symbol source)
        {
            value = source;
        }
    }
}