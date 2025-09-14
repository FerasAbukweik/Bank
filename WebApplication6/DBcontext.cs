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

            modelBuilder.Entity<transactionStatus>().HasData(
                new transactionStatus { id = 1, status = "Pending" },
                new transactionStatus { id = 2, status = "Completed" },
                new transactionStatus { id = 3, status = "Failed" },
                new transactionStatus { id = 4, status = "Canceled" });

            modelBuilder.Entity<transactionTypes>().HasData(
                new transactionTypes { id = 1, type = "Deposit" },
                new transactionTypes { id = 2, type = "Withdrawal" },
                new transactionTypes { id = 3, type = "Send" },
                new transactionTypes { id = 4, type = "Receive" }
                );

            modelBuilder.Entity<AccountTypes>().HasData(
                new AccountTypes { id = 1, type = "Savings" },
                new AccountTypes { id = 2, type = "Current_Checking" },
                new AccountTypes { id = 3, type = "Fixed_Deposit" },
                new AccountTypes { id = 4, type = "Recurring_Deposit" },
                new AccountTypes { id = 5, type = "NRI_Accounts" });
        }

        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<BankTransaction> transactions { get; set; }
        public DbSet<Transfer> transfers { get; set; }
        public DbSet<transactionTypes> transactionInfo { get; set; }
        public DbSet<transactionStatus> transactionStatuses { get; set; }
        public DbSet<AccountTypes> accountInfo { get; set; }

    }
}
