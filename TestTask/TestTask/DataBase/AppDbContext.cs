using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Incident>().HasKey(m => m.Name);
            modelBuilder.Entity<Incident>().Property(m => m.Name).ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>().HasIndex(m => m.Email).IsUnique();
            modelBuilder.Entity<Contact>().HasOne(m => m.Account).WithMany(m => m.Contacts).HasForeignKey(m => m.AccountId);

            modelBuilder.Entity<Account>().HasIndex(m => m.Name).IsUnique();
            modelBuilder.Entity<Account>().HasOne(m => m.Incident).WithMany(m => m.Accounts).HasForeignKey(m => m.IncidentName);
        }
    }
}
