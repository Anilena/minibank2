using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace minibank_client_api.Models
{
    public class ClientRepositoryDbPostgreSQl : DbContext, IClientRepository
    {
        private readonly string? _connectionString;
        public DbSet<ClientDb> dbClients { get; set; }

        public ClientRepositoryDbPostgreSQl(string? connectionString)
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
            });
            modelBuilder.HasDefaultSchema("sh_clients");
            base.OnModelCreating(modelBuilder);
        }

        public ClientDb? GetByUserName(String username)
        {
            using (var db = new ClientRepositoryDbPostgreSQl(_connectionString))
            {
                return db.dbClients
               .FirstOrDefault(item => item.UserName == username);
            }
            //добавить обработку исключения
        }
        public ClientDb? Add(ClientDb item)
        {
            using var db = new ClientRepositoryDbPostgreSQl(_connectionString);
            db.dbClients.Add(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByUserName(item.UserName);
        }
        public ClientDb? Update(ClientDb item)
        {
            using var db = new ClientRepositoryDbPostgreSQl(_connectionString);
            db.dbClients.Update(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByUserName(item.UserName);
        }
        public Boolean Remove(ClientDb item)
        {
            using (var db = new ClientRepositoryDbPostgreSQl(_connectionString))
            {
                db.dbClients.Remove(item);
                db.SaveChanges();
            }
            //добавить обработку исключения
            //изменить ответ - а то всегда true
            return true;
        }
    }
}