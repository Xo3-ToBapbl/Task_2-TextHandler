﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.CreatersInterfaces
{
    interface ISentenceItemCreator
    {
        ISentenceItem Create(string chars);
    }
}
