using System.Collections.Generic;
using System.Linq;
using MessAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessAPI
{
    public class DatabaseRepository : IMessageRepository
    {
        private readonly MessageDbContext dbContext = new MessageDbContext();

        public List<Message> ShowAllMessages()
        {
            return dbContext.Messages.ToList();
        }


        public Message AddMessage(Message message)
        {
            dbContext.Messages.Add(new Message { Id = message.Id, Title = message.Title, Body = message.Body });
            dbContext.SaveChanges();
            return dbContext.Messages.Find(message.Id);
        }


        public IEnumerable<Message> ChangeMessage(Message messageFromBody)
        {
            Message messageFromMethod = dbContext.Messages.Find(messageFromBody.Id);
            messageFromMethod.Title = messageFromBody.Title;
            messageFromMethod.Body = messageFromBody.Body;
            dbContext.SaveChanges();
            return dbContext.Messages.ToList();
        }


        public IEnumerable<Message> DeleteMessage(int id)
        {
            Message MessageToRemove = dbContext.Messages.Find(id);
            dbContext.Remove(MessageToRemove);
            dbContext.SaveChanges();
            return dbContext.Messages.ToList();
        }
    }
}
