using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class MyMailDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }  //delete late
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Atachment> Atachments { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(x => x.Contacts)
                .WithMany(x => x.Contacts).Map(x =>
                {
                    x.ToTable("Contacts");
                    x.MapLeftKey("Contact1");
                    x.MapRightKey("Contact2");
                });
        }
    }
}
