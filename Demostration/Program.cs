﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.Structs;
using TextHandlerLibrary.SenstenseItemsClasses;
using System.IO;
using System.Configuration;
using TextHandlerLibrary.TextParser;
using TextHandlerLibrary.SenstenseItemsClasses;
using TextHandlerLibrary.Creaters;
using TextHandlerLibrary.SenstenseItemsInterfaces;
using TextHandlerLibrary.SymbolContainers;

namespace Demostration
{
    class Program
    {
        static void Main()
        {
            #region Letters
            //char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            //char[] coconsonants = {'b', 'c', 'd', 'f', 'g', 'h',
            //                      'j', 'k', 'l', 'm', 'n', 'p',
            //                      'r', 's', 't', 'v', 'w', 'x', 'z'};
            #endregion

            string path = ConfigurationManager.AppSettings["TextFilePath"];
            TextParser textParser = new TextParser();
            SymbolContainer sc = new SymbolContainer(); 

            WordCreater wordCreator = new WordCreater(sc);
            ISentenceItem word = wordCreator.Create("FoiAcccG");

            Console.ReadKey();
        }
    }
}
