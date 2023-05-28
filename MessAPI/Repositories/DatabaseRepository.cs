﻿using MessAPI.Data;
using MessAPI.Models;
using MessAPI.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
