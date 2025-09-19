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
                new BankRole { id = 1, role = 32703, roleName = "Client" }, //=> fornow eveything except managing roles and filter users
                new BankRole { id = 2, role = -1 , roleName = "Admin" }); // -1 => Full Access

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, userName = "Admin", hashedPassword = "$2a$11$g3QSh3R50Hq2d6uzp1GoAeBtQeCXDNWJlKDbqv0kYj7IZ1zEIBF3q", email = "admin@gmail.com", phone = "", createdAt = new DateTime(2025, 9, 16, 13, 12, 39, 713, DateTimeKind.Local).AddTicks(6689), BankRole_id = 2, }
                );
        }

        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transfer> transfers { get; set; }
        public DbSet<AccountType> accountTypes { get; set; }
        public DbSet<BankRole> bankRoles { get; set; }

    }
}
