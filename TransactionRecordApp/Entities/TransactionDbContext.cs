using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TransactionRecordApp.Entities
{
    /// <summary>
    /// This class will inherit from the Entity Framework (EF) class
    /// called DbContext and is used by the code to interact with the DB
    /// </summary>
    public class TransactionDbContext : DbContext
    {
        /// <summary>
        /// Define a constructor that simply passes the options argument
        /// up to the base class constuctor
        /// </summary>
        /// <param name="options"></param>
        public TransactionDbContext(DbContextOptions options)
            : base(options)
        {
            // Ensure the database is created
            EnsureDbIsCreated();
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    TransactionId = 1,
                    TickerSymbol = "AAPL",
                    CompanyName = "Apple Inc.",
                    Quantity = 2,
                    SharePrice = 194.62
                },
                new Transaction
                {
                    TransactionId = 2,
                    TickerSymbol = "F",
                    CompanyName = "Ford Motors Company",
                    Quantity = 5,
                    SharePrice = 8.50
                },
                new Transaction
                {
                    TransactionId = 3,
                    TickerSymbol = "GOOGL",
                    CompanyName = "Alphabet Inc.",
                    Quantity = 1,
                    SharePrice = 1022.37
                },
                new Transaction
                {
                    TransactionId = 4,
                    TickerSymbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Quantity = 10,
                    SharePrice = 107.71
                }
            );
        }

        private void EnsureDbIsCreated()
        {
            Database.EnsureCreated();
        }

    }
}
