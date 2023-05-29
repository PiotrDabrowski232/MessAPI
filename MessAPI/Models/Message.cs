using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }



        public Message()
        {
        }



        public Message(int id)
        {
            Id = id;
        }



        public Message(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }



        public Message(int id, string title, string body, string type)
        {
            Id = id;
            Title = title;
            Body = body;
            Type = type;
        }

        public void ChangeMessageByNotNullProperties(Message message)
        {
            if(message.Title != null)
                Title = message.Title;
            
            if(message.Body != null)
                Body = message.Body;

            if(message.Type != null)
                Type = message.Type;
        }
    }
}
