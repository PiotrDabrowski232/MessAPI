using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class MessService 
    {
        
        public List<MessaClass> Mess = new List<MessaClass>();
        public MessaClass[] Mscg = new MessaClass[1]; 


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
            for(int i=0; i<MessTitles.Length;i++){
               
                Mess.Add(new MessaClass() { MessClassId = Mess.Count, MessClassTitles = MessTitles[i], MessClassBody = MessBody[i] });
            }
            return Mess.ToArray();
            
        }
        public IEnumerable<MessaClass> Get(int id)
        {
            Get();
            foreach(MessaClass Mes in Mess)
            {
                if(Mes.MessClassId == id)
                {
                 Mscg[0] = Mes;
                }
            }
            return Mscg.ToArray();
        }

        public IEnumerable<MessaClass> Post(string addedTitle, string addedBody)
        {
            Get();
           Mess.Add(new MessaClass() { MessClassId = Mess.Count, MessClassTitles = addedTitle, MessClassBody = addedBody });
            //Mess.Add(new MessaClass() { MessClassId = Mess.Count, MessClassTitles = addedTitle, MessClassBody = addedBody });
            return Mess.ToArray();
        }
        public IEnumerable<MessaClass> Put(int id, string titleToChange)
        {
            Get();
            foreach(MessaClass MsCls in Mess)
            {
             if (Equals(id, MsCls.MessClassId))
                {
                    MsCls.MessClassTitles = titleToChange;
                    Mscg[0] = MsCls;
                } 
            }
            return Mscg.ToArray();
        }
        public IEnumerable<MessaClass> Delete(int id)
        {
            Get();

            for (int i = 0; i < Mess.Count; i++)
                {
                MessaClass MsCls = Mess[i];
                if (Equals(id, MsCls.MessClassId))
                    {
                    Mess.Remove(MsCls);
                    }
                 Mess.ToArray();
                }
            return Mess;
            }
            
        
    }
}
