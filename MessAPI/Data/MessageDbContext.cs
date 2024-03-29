﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MessAPI.Data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Message>().Property(x => x.Title).IsRequired().HasMaxLength(50);
            modelbuilder.Entity<Message>().Property(x => x.Type).HasMaxLength(20).HasDefaultValue("neutral");

        }
    }
}
