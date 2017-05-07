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

            textParser.SentenceItemParser();
            

            Console.ReadKey();
        }
    }
}
