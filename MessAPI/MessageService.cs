using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class MessageService
    {
        public List<Message> ListOfMessages;
        public Message message = new Message();

        public List<Message> Get()
        {
            ListOfMessages = message.ListOFList();
            return ListOfMessages;
        }


        public List<Message> Post(string addTitle, string addBody) {
            int MessageID = message.ListOFList().Count;
            message.AddTo_List_Of_Messages(new Message(MessageID, addTitle, addBody));
            ListOfMessages = message.ListOFList();
            return ListOfMessages; 
        }




        /* 


         public IEnumerable<Message> Put(int id, string titleToChange)
         {
             Get();
             foreach(Message MsCls in MessagesList)
             {
              if (Equals(id, MsCls.Id))
                 {
                     MsCls.Title = titleToChange;
                     Mscg[0] = MsCls;
                 } 
             }
             return Mscg.ToArray();
         }
         public IEnumerable<Message> Delete(int id)
         {
             Get();

             for (int i = 0; i < MessagesList.Count; i++)
                 {
                 Message MsCls = MessagesList[i];
                 if (Equals(id, MsCls.Id))
                     {
                     MessagesList.Remove(MsCls);
                     }
                 MessagesList.ToArray();
                 }
             return MessagesList;
             }*/


    }
}
