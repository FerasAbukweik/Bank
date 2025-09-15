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

            modelBuilder.Entity<BankTransactionStatus>().HasData(
                new BankTransactionStatus { id = 1, status = "Pending" },
                new BankTransactionStatus { id = 2, status = "Completed" },
                new BankTransactionStatus { id = 3, status = "Failed" },
                new BankTransactionStatus { id = 4, status = "Canceled" });

            modelBuilder.Entity<BankTransactionType>().HasData(
                new BankTransactionType { id = 1, type = "Deposit" },
                new BankTransactionType { id = 2, type = "Withdrawal" },
                new BankTransactionType { id = 3, type = "Send" },
                new BankTransactionType { id = 4, type = "Receive" });

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { id = 1, type = "Savings" },
                new AccountType { id = 2, type = "Current_Checking" },
                new AccountType { id = 3, type = "Fixed_Deposit" },
                new AccountType { id = 4, type = "Recurring_Deposit" },
                new AccountType { id = 5, type = "NRI_Accounts" });

            modelBuilder.Entity<BankRole>().HasData(
                new BankRole { id = 1, role = "Admin" },
                new BankRole { id = 2, role = "Manager" },
                new BankRole { id = 3, role = "customer" });
        }

        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<BankTransaction> bankTransactions { get; set; }
        public DbSet<Transfer> transfers { get; set; }
        public DbSet<BankTransactionType> bankTransactionInfo { get; set; }
        public DbSet<BankTransactionStatus> bankTransactionStatuses { get; set; }
        public DbSet<AccountType> accountInfo { get; set; }
        public DbSet<BankRole> bankRoles { get; set; }

    }
}
