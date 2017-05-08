using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.TextClass
{
    public class Text
    {
        public ICollection<ISentence> Sentences { get; set; }
        public int SentencesCount
        {
            get
            {
                return Sentences.Count;
            }
        }

        public Text()
        {
            Sentences = new List<ISentence>();
        }
    }
}
