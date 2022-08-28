using System.Collections.Generic;

namespace MessAPI
{
    public interface IMessageRepository
    {
        Message AddMessage(Message message);
        IEnumerable<Message> ChangeMessage(Message message);
        IEnumerable<Message> DeleteMessage(int id);
        List<Message> ShowAllMessages();
    }
}