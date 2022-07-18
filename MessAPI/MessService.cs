using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class MessService
    {


        /*  public List<string> MessTitles = new List<string>() { "tytul1", "tytul2", "tytul3", "tytul4", "tytul5" };

          public List<string> MessBody = new List<string>() { "tresc1", "tresc2", "tresc3", "tresc4", "tresc5" };*/

        public string[] MessTitles = new[]
        {
            "tytul1", "tytul2", "tytul3", "tytul4", "tytul5"
        };
        public string[] MessBody = new[]
        {
            "tresc1", "tresc2", "tresc3", "tresc4", "tresc5"
        };

        public IEnumerable<MessaClass> Get()
        {
            int indexerT = MessTitles.Length;
            int indexerB = MessBody.Length;
            return Enumerable.Range(1, 5).Select(index => new MessaClass
            {
                MessClassTitles = MessTitles[--indexerT],
                MessClassBody = MessBody[--indexerB]
            }).ToArray();
        }
    }
}
