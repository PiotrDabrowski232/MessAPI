using MessAPI.Models;
using System.Collections.Generic;

namespace MessAPI.Repositories
{
    public interface IMessageRepository
    {
        Message AddMessage(Message message);
        IEnumerable<Message> ChangeMessage(Message message);
        IEnumerable<Message> DeleteMessage(int id);
        List<Message> ShowAllMessages();
    }
}