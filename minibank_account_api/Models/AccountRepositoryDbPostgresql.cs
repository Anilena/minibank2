using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace minibank_account_api.Models
{
    public class AccountRepositoryDbPostgreSQL : DbContext, IAccountRepository
    {
        private readonly string? _connectionString;

        public DbSet<AccountDb> dbAccounts { get; set; }

        public AccountRepositoryDbPostgreSQL(string? connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(connectionString:_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDb>(e => e.ToTable("account"));
            modelBuilder.Entity<AccountDb>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").HasDefaultValue();
                entity.Property(e => e.No).HasColumnName("no").HasDefaultValue();
                entity.Property(e => e.ClientGuid).HasColumnName("client_guid");
                entity.Property(e => e.Balance).HasColumnName("balance");
                entity.Property(e => e.Currency).HasColumnName("currency").HasDefaultValue();
            });
            modelBuilder.HasDefaultSchema("sh_accounts");
            base.OnModelCreating(modelBuilder);
        }
        public IEnumerable<AccountDb> GetByUser(Guid clientguid)
        {   
            var acc = new List<AccountDb>();
            using (var db = new AccountRepositoryDbPostgreSQL(_connectionString))
            {
                var accDB = db.dbAccounts
                .Where(item => item.ClientGuid == clientguid);

                foreach (var item1 in accDB)
                {
                    acc.Add(item1);
                    //return new ArraySegment<AccountDb>();
                }
            }
            return acc;
        }
        public AccountDb? GetByNo(string no)
        {
            using (var db = new AccountRepositoryDbPostgreSQL(_connectionString))
            {
                return db.dbAccounts
               .FirstOrDefault(item => item.No == no);
            }
        }

        public AccountDb? Add(AccountDb item)
        {
            using var db = new AccountRepositoryDbPostgreSQL(_connectionString);
            db.dbAccounts.Add(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByNo(item.No);
        }
        public AccountDb? Update(AccountDb item)
        {
            using var db = new AccountRepositoryDbPostgreSQL(_connectionString);
            db.dbAccounts.Update(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByNo(item.No);
        }
        public bool Remove(AccountDb item)
        {
            using (var db = new AccountRepositoryDbPostgreSQL(_connectionString))
            {
                db.dbAccounts.Remove(item);
                db.SaveChanges();
            }
            //добавить обработку исключения
            //изменить ответ - а то всегда true
            return true;
        }
    }
}
