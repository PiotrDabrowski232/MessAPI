using System.Collections.Generic;

namespace MessAPI
{
    public interface IMessageRepository
    {
        IEnumerable<Message> AddMessage(string addedTitle, string addedBody);
        IEnumerable<Message> ChangeTitle(int id, string titleToChange);
        IEnumerable<Message> DeleteMessage(int id);
        List<Message> ShowAllMessages();
        

       private static List<Message> Messages { get; set; }
    }
}