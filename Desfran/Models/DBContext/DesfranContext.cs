using Desfran.Models.Entities;
using Desfran.Models.Helpers;
using Microsoft.EntityFrameworkCore;
namespace Desfran.Models.DBContext
{
    public class DesfranContext : DbContext
    {
        public DesfranContext(DbContextOptions<DesfranContext> option) : base(option) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = CreateUser();
            modelBuilder.Entity<Account>().HasData(user);
        }

        public static Account CreateUser()
        {
            var encryptedPassword = HashEncryptedHelper.HashPassword("Admin@123");

            var user = new Account()
            {
                Id=1,
                Username = "Admin",
                Email = "Admin@gmail.com",
                Password = encryptedPassword
            };

            return user;
        }
    }
}