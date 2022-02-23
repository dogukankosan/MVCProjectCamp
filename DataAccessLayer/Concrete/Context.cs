using EntitiyLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
