using Microsoft.EntityFrameworkCore;
using minibank_account_api.Controllers;

namespace minibank_account_api.Models
{
    public class AccountRepositoryDbPostgreSQL : DbContext, IAccountRepository
    {
        private readonly string? _connectionString;

        private readonly ILogger<AccountController> _logger;
        public DbSet<AccountDb> dbAccounts { get; set; }

        public AccountRepositoryDbPostgreSQL(string? connectionString, ILogger<AccountController> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(connectionString: _connectionString);
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
#if DEBUG
            _logger.LogInformation("GetAccountsByUser");
#endif
            try
            {
                using (var db = new AccountRepositoryDbPostgreSQL(_connectionString, _logger))
                {
                    var accDB = db.dbAccounts
                    .Where(item => item.ClientGuid == clientguid);

                    foreach (var item1 in accDB)
                    {
                        acc.Add(item1);
                    }
                }
            }
            catch (Exception e) { _logger.LogError("Error.GetAccountsByUser" + e.Message); }

            return acc;
        }
        public AccountDb? GetByNo(string no)
        {
#if DEBUG
            _logger.LogInformation("GetAccountByNo");
#endif
            try
            {
                using (var db = new AccountRepositoryDbPostgreSQL(_connectionString, _logger))
                {
                    return db.dbAccounts
                   .FirstOrDefault(item => item.No == no);
                }
            }
            catch (Exception e) { _logger.LogError("Error.GetAccountByNo" + e.Message); }

            return null;
        }
        public AccountDb? Add(AccountDb item)
        {
#if DEBUG
            _logger.LogInformation("Add");
#endif
            try
            {
                using var db = new AccountRepositoryDbPostgreSQL(_connectionString, _logger);
                db.dbAccounts.Add(item);
                db.SaveChanges();
                return GetByNo(item.No);
            }
            catch (Exception e) { _logger.LogError("Error.Add" + e.Message); }

            return null;
        }
        public AccountDb? Update(AccountDb item)
        {
#if DEBUG
            _logger.LogInformation("Update");
#endif
            try
            {
                using var db = new AccountRepositoryDbPostgreSQL(_connectionString, _logger);
                db.dbAccounts.Update(item);
                db.SaveChanges();
                return GetByNo(item.No);
            }
            catch (Exception e) { _logger.LogError("Error.Update" + e.Message); }
            return null;
        }
        public bool Remove(AccountDb item)
        {
#if DEBUG
            _logger.LogInformation("Remove");
#endif
            try
            {
                using (var db = new AccountRepositoryDbPostgreSQL(_connectionString, _logger))
                {
                    db.dbAccounts.Remove(item);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e) { _logger.LogError("Error.Remove" + e.Message); }

            return false;
        }
    }
}
