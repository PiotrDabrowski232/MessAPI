using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class MessService
    {


         public List<MessaClass> Mess = new List<MessaClass>();

         
        public string[] MessTitles = new[]
        {
            "tytul1", "tytul2", "tytul3", "tytul4", "tytul5"
        };
        public string[] MessBody = new[]
        {
            "tresc1", "tresc2", "tresc3", "tresc4", "tresc5"
        };

        public void allList()
        {
            for(int i=0; i<MessTitles.Length;i++){
                Mess.Add(new MessaClass() { MessClassTitles = MessTitles[i], MessClassBody = MessBody[i] });
            }
        }
        public IEnumerable<MessaClass> Get()
        {
            allList();
            return Mess.ToArray();
            /*int indexerT = MessTitles.Length;
            int indexerB = MessBody.Length;
            return Enumerable.Range(1, 5).Select(index => new MessaClass
            {
                MessClassTitles = MessTitles[--indexerT],
                MessClassBody = MessBody[--indexerB]
            }).ToArray();*/
        }
        public IEnumerable<MessaClass> Post(string addedTitle, string addedBody)
        {
            Mess.Add(new MessaClass() { MessClassTitles = addedTitle, MessClassBody = addedBody });
            return Mess.ToArray();
        }
        
    }
}
