using System;
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
using TextHandlerLibrary.TextItemsClasses;
using TextHandlerLibrary.TextClass;

namespace Demostration
{
    class Program
    {
        static void Main()
        {
            string path = ConfigurationManager.AppSettings["TextFilePath"];
            SymbolContainer symbolContainer = new SymbolContainer();

            TextParser textParser = new TextParser(symbolContainer);
            Text text = textParser.ParseText(path);
        }
    }
}
