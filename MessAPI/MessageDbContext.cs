using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MessAPI.Entities
{
    public class MessageDbContext:DbContext
    {
        private readonly string _connectionString = "Server=.\\mssqlserver01;Database=MessageApi;Trusted_Connection=True;";

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Message>().Property(MessageIdMustBeRequired => MessageIdMustBeRequired.Title).IsRequired().HasMaxLength(50);\
        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
