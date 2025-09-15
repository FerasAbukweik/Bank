using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Transactions;
using WebApplication6.Models;

namespace WebApplication6
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { id = 1, type = "Savings" },
                new AccountType { id = 2, type = "Current/Checking" },
                new AccountType { id = 3, type = "Fixed/Deposit" },
                new AccountType { id = 4, type = "Recurring/Deposit" },
                new AccountType { id = 5, type = "NRI/Accounts" });

            modelBuilder.Entity<BankRole>().HasData(
                new BankRole { id = 1, role = 447, roleName = "Client" }, 
                new BankRole { id = 3, role = -1 , roleName = "Admin" }); // -1 => Full Access
        }

        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transfer> transfers { get; set; }
        public DbSet<AccountType> accountInfo { get; set; }
        public DbSet<BankRole> bankRoles { get; set; }

    }
}
