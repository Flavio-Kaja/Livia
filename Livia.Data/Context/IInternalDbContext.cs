using Microsoft.EntityFrameworkCore;

namespace Livia.Data.Context
{
    public interface IInternalDbContext : IDbContext
    {
        public DbSet<Domain.Models.Task.Task> Tasks { get; set; }
        public DbSet<Domain.Models.Task.Tag> Tags { get; set; }
        public DbSet<Domain.Models.Task.Category> Categories { get; set; }
        public DbSet<Domain.Models.Task.Comment> Comments { get; set; }
        public DbSet<Domain.Models.Communication.Channel> Channels { get; set; }
        public DbSet<Domain.Models.Communication.Message> Messages { get; set; }
        public DbSet<Domain.Models.Communication.Notification> Notifications { get; set; }
        public DbSet<Domain.Models.User.AppUser> AppUsers { get; set; }
        public DbSet<Domain.Models.User.Person> Persons { get; set; }
    }
}