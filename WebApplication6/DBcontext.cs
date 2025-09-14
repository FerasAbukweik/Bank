using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using WebApplication6.Models;

namespace WebApplication6
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionInfo>().HasData(
                // majorCode = 1 -> transactionStatus                             minorCode ↓
                new TransactionInfo { id = 1, majorCode = 1, minorCode = 1, info = "Pending" },
                new TransactionInfo { id = 2, majorCode = 1, minorCode = 2, info = "Completed" },
                new TransactionInfo { id = 3, majorCode = 1, minorCode = 3, info = "Failed" },
                new TransactionInfo { id = 4, majorCode = 1, minorCode = 4, info = "Canceled" },

                // majorCode = 2 -> transactionTypes                              minorCode ↓
                new TransactionInfo { id = 5, majorCode = 2, minorCode = 1, info = "Deposit" },
                new TransactionInfo { id = 6, majorCode = 2, minorCode = 2, info = "Withdrawal" }
                );

            modelBuilder.Entity<AccountInfo>().HasData(
                // majorCode = 1 -> accountTypes                                  minorCode ↓
                new TransactionInfo { id = 1, majorCode = 1, minorCode = 1, info = "Savings" },
                new TransactionInfo { id = 2, majorCode = 1, minorCode = 2, info = "Current_Checking" },
                new TransactionInfo { id = 3, majorCode = 1, minorCode = 3, info = "Fixed_Deposit" },
                new TransactionInfo { id = 4, majorCode = 1, minorCode = 4, info = "Recurring_Deposit" },
                new TransactionInfo { id = 5, majorCode = 1, minorCode = 5, info = "NRI_Accounts" }
                );

        }

        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Transfer> transfers { get; set; }
        public DbSet<TransactionInfo> transactionInfo { get; set; }
        public DbSet<AccountInfo> accountInfo { get; set; }

    }
}
