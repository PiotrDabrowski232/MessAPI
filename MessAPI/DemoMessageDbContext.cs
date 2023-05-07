using MessAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MessAPI
{
    public class DemoMessageDbContext : MessageDbContext
    {
        public DemoMessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
    }
}
