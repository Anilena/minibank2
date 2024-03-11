using Microsoft.EntityFrameworkCore;
using minibank_client_api.Controllers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace minibank_client_api.Models
{
    public class ClientRepositoryDbPostgreSQl : DbContext, IClientRepository
    {
        private readonly ILogger<ClientController> _logger;

        private readonly string? _connectionString;
        public DbSet<ClientDb> dbClients { get; set; }

        public ClientRepositoryDbPostgreSQl(string? connectionString, ILogger<ClientController> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:_connectionString);
            //optionsBuilder.UseNpgsql(_connectionString, builder =>
            //{
            //    builder.RemoteCertificateValidationCallback((s, c, ch, sslPolicyErrors) =>
            //    {
            //        if (sslPolicyErrors == SslPolicyErrors.None)
            //        {
            //            return true;
            //        }
            //        _logger.LogError($@"Certificate error: {sslPolicyErrors}");
            //        return false;
            //    });
            //    //builder.ProvideClientCertificatesCallback (clientCerts =>
            //    //{
            //    //    var clientCertPath = "C:\\Users\\anile\\.postgresql\\root.crt";
            //    //    var cert = new X509Certificate2(clientCertPath);
            //    //    clientCerts.Add(cert);
            //    //});
            //});
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientDb>(e => e.ToTable("client"));
            modelBuilder.Entity<ClientDb>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").HasDefaultValue();
                entity.Property(e => e.GUID).HasColumnName("guid").HasDefaultValue();    
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.SecondName).HasColumnName("second_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Token).HasColumnName("token");
                entity.Property(e => e.CreateDate).HasColumnName("create_date");
            });
            modelBuilder.HasDefaultSchema("sh_clients");
            base.OnModelCreating(modelBuilder);
        }

        public ClientDb? GetByUserName(String username)
        {
#if DEBUG
            _logger.LogInformation("GetByUserName");
#endif
            try
            {
                using (var db = new ClientRepositoryDbPostgreSQl(_connectionString, _logger))
                {
                  
                    return db.dbClients
               .FirstOrDefault(item => item.UserName == username);
                }
            }
            catch (Exception e) { _logger.LogError("Error.GetByUserName" + e.Message); }

            return null;
        }
        
        public ClientDb? Add(ClientDb item)
        {
#if DEBUG
            _logger.LogInformation("Add");
#endif
            try
            {
                using var db = new ClientRepositoryDbPostgreSQl(_connectionString, _logger);
                db.dbClients.Add(item);
                db.SaveChanges();
            }
            catch (Exception e) { _logger.LogDebug("Error.Add" + e.Message); }
            
            return GetByUserName(item.UserName);
        }
        public ClientDb? Update(ClientDb item)
        {
#if DEBUG
            _logger.LogInformation("Update");
#endif
            try
            {
                using var db = new ClientRepositoryDbPostgreSQl(_connectionString, _logger);
                db.dbClients.Update(item);
                db.SaveChanges();
            }
            catch (Exception e) { _logger.LogDebug("Error.Update" + e.Message); }
            
            return GetByUserName(item.UserName);
        }
        public Boolean Remove(ClientDb item)
        {
#if DEBUG
            _logger.LogInformation("Remove");
#endif
            try
            {
                using (var db = new ClientRepositoryDbPostgreSQl(_connectionString, _logger))
                {
                    db.dbClients.Remove(item);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { _logger.LogDebug("Error.Remove" + e.Message); }

            return false;
        }
    }
}