using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI
{
    public class InMemoryRepository : IMessageRepository
    {
        public static List<Message> ListOfMessages = new List<Message>();




        public List<Message> ShowAllMessages()
        {
            return ListOfMessages;
        }




        public Message AddMessage(Message message)
        {
           ListOfMessages.Add(new Message() { Id = ListOfMessages.Count, Title = message.Title, Body = message.Body });
            return ListOfMessages.Last();
        }



        public IEnumerable<Message> ChangeMessage(Message messageFromBody)
        {
            Message messageFromMethod = new Message();

            for (int i = 0; i < ListOfMessages.Count; i++)
            {
                messageFromMethod = ListOfMessages[i];

                if (Equals(messageFromBody.Id, messageFromMethod.Id))
                {
                    messageFromMethod.Title = messageFromBody.Title;
                    messageFromMethod.Body = messageFromBody.Body;
                }
            }
           
            return ListOfMessages.ToArray();
        }



        public IEnumerable<Message> DeleteMessage(int id)
        {
            var result = ListOfMessages.RemoveAll(ifEquals => ifEquals.Id == id);
            return ListOfMessages;
        }


    }
}
