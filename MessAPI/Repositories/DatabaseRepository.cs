using MessAPI.Data;
using MessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MessAPI.Repositories
{
    public class DatabaseRepository : IMessageRepository
    {


        private readonly MessageDbContext _dbContext;
        public DatabaseRepository(MessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public List<Message> ShowAllMessages()
        {
            return _dbContext.Messages.ToList();
        }




        public Message AddMessage(Message message)
        {
            if (message.Type == null)
                _dbContext.Messages.Add(new Message { Id = message.Id, Title = message.Title, Body = message.Body, Type = "neutral" });

            else if (message.Type.ToUpper() == "POSITIVE" || message.Type.ToUpper() == "NEGATIVE" || message.Type.ToUpper() == "NEUTRAL" || message.Type.ToUpper() == "")
            {

                if (message.Type.ToUpper() == "")
                    _dbContext.Messages.Add(new Message { Id = message.Id, Title = message.Title, Body = message.Body, Type = "neutral" });

                else
                    _dbContext.Messages.Add(new Message { Id = message.Id, Title = message.Title, Body = message.Body, Type = message.Type });
            }
            else
                throw new ArgumentException("Type of message should be negative, positive, neutral or you can leave this value empty");


            _dbContext.SaveChanges();
            return _dbContext.Messages.Find(message.Id);
        }




        public IEnumerable<Message> ChangeMessage(Message messageFromBody)
        {
            Message messageFromMethod = _dbContext.Messages.Find(messageFromBody.Id);
            if (messageFromBody.Title == null)
            {
                messageFromMethod.Body = messageFromBody.Body;
            }
            else if (messageFromBody.Body == null)
            {
                messageFromMethod.Title = messageFromBody.Title;
            }
            else if (messageFromBody.Body == null && messageFromBody.Title == null)
            {
                messageFromMethod.Title = messageFromMethod.Title;
                messageFromMethod.Body = messageFromMethod.Body;
            }
            else
            {
                messageFromMethod.Title = messageFromBody.Title;
                messageFromMethod.Body = messageFromBody.Body;
            }

            _dbContext.SaveChanges();


            return _dbContext.Messages.ToList();
        }




        public IEnumerable<Message> DeleteMessage(int id)
        {
            Message MessageToRemove = _dbContext.Messages.Find(id);
            _dbContext.Remove(MessageToRemove);
            _dbContext.SaveChanges();


            return _dbContext.Messages.ToList();
        }
    }
}
