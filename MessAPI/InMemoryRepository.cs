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




        public IEnumerable<Message> AddMessage(string addedTitle, string addedBody)
        {
            ListOfMessages.Add(new Message() { Id = ListOfMessages.Count, Title = addedTitle, Body = addedBody });
            return ListOfMessages.ToArray();
        }



        public IEnumerable<Message> ChangeTitle(int id, string titleToChange)
        {
            Message message = new Message();

            for (int i = 0; i < ListOfMessages.Count; i++)
            {
                message = ListOfMessages[i];

                if (Equals(id, message.Id))
                {
                    message.Title = titleToChange;
                    ListOfMessages[i] = message;
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
