using System.Collections.Generic;

namespace MessAPI
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<Message> List_Of_Messages= new List<Message>();

        public Message(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
        public Message()
        {
        }
        public List<Message> ListOFList()
        {
            return List_Of_Messages;
        }

        public void AddTo_List_Of_Messages(Message message)
        {
            List_Of_Messages.Add(message);
        }
       
    }
}
