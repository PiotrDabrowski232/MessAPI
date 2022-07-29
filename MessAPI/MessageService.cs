using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class MessageService
    {
        public static List<Message> ListOfMessages = new List<Message>();
        public Message message = new Message();

        public List<Message> Get()
        {
            return ListOfMessages;
        }


        public IEnumerable<Message> Post(string addedTitle, string addedBody)
        {
            ListOfMessages.Add(new Message() { Id = ListOfMessages.Count, Title = addedTitle, Body = addedBody });
            return ListOfMessages.ToArray();
        }

         public IEnumerable<Message> Put(int id, string titleToChange)
         {

            for(int i = 0; i<ListOfMessages.Count; i++)
            {
                message = ListOfMessages[i];
                if(Equals(id, message.Id)){
                    message.Title = titleToChange;
                    ListOfMessages[i] = message;
                }
            }
             return ListOfMessages.ToArray();
         }

         public IEnumerable<Message> Delete(int id)
         {
             for (int i = 0; i < ListOfMessages.Count; i++)
                 {
                 Message MsCls = ListOfMessages[i];
                 if (Equals(id, MsCls.Id))
                     {
                    ListOfMessages.Remove(MsCls);
                     }
                ListOfMessages.ToArray();
                 }
             return ListOfMessages;
             }


    }
}
