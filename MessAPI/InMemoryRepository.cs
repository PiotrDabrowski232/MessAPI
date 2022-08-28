using System.Collections.Generic;
using System.Linq;

namespace MessAPI
{
    public class InMemoryRepository : IMessageRepository
    {
        private static List<Message> listOfMessages = new();

        public static List<Message> ListOfMessages { get => listOfMessages; set => listOfMessages = value; }

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
            Message messageFromMethod = ListOfMessages.Find(ifEquals => messageFromBody.Id == ifEquals.Id);
            messageFromMethod.Title = messageFromBody.Title;
            messageFromMethod.Body = messageFromBody.Body;
            return ListOfMessages.ToArray();
        }


        public IEnumerable<Message> DeleteMessage(int id)
        {
            Message MessageToRemove = ListOfMessages.Find(trash => trash.Id == id);
            ListOfMessages.Remove(MessageToRemove);
            return ListOfMessages;
        }
    }
}
