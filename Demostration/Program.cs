using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.Structs;
using TextHandlerLibrary.SenstenseItemsClasses;
using System.IO;
using System.Configuration;

namespace Demostration
{
    class Program
    {
        static string StringParser(string _string)
        {
            return _string.Trim();
        }

        static void Main()
        {
            #region Letters
            //char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            //char[] coconsonants = {'b', 'c', 'd', 'f', 'g', 'h',
            //                      'j', 'k', 'l', 'm', 'n', 'p',
            //                      'r', 's', 't', 'v', 'w', 'x', 'z'};
            #endregion
            #region File
            string path = ConfigurationManager.AppSettings["TextFilePath"];
            StreamReader TextFile = new StreamReader(path);
            string _string = TextFile.ReadLine();
            TextFile.Close();
            #endregion

            Word word = new Word(_string);

            Console.ReadKey();
        }
    }
}
