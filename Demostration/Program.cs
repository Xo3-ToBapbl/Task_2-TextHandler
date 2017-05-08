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

namespace Demostration
{
    class Program
    {
        static void Main()
        {
            string path = ConfigurationManager.AppSettings["TextFilePath"];
            SymbolContainer symbolContainer = new SymbolContainer();

            TextParser textParser = new TextParser(symbolContainer);
            WordCreater wordCreator = new WordCreater(symbolContainer);

            ISentenceItem word1 = wordCreator.Create("FoiAcccG");
            ISentenceItem word2 = wordCreator.Create("Masa");
            ISentenceItem word3 = wordCreator.Create("Mdddasa");

            ISentence sentence = new Sentence(new List<ISentenceItem>());

            sentence.Add(word1);
            sentence.Add(word2);
            sentence.Add(word3);

            sentence.RemoveAtInd(1);

            Console.ReadKey();
        }
    }
}
