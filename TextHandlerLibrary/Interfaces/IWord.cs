﻿using System.Collections.Generic;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.Interfaces
{
    public interface IWord: ISentenceItem, IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
    }
}
