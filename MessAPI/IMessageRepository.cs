using System.Collections.Generic;

namespace MessAPI
{
    public interface IMessageRepository
    {
        IEnumerable<Message> AddMessage(Message message);
        IEnumerable<Message> ChangeMessage(Message message);
        IEnumerable<Message> DeleteMessage(int id);
        List<Message> ShowAllMessages();
        

       private static List<Message> Messages { get; set; }
    }
}