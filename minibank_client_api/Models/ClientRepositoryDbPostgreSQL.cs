using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace minibank_client_api.Models
{
    public class ClientRepositoryDbPostgreSQl : DbContext, IClientRepository
    {
        public DbSet<Client> dbClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
               "Server=rc1b-5e7n4vksf85yfbsb.mdb.yandexcloud.net;Port=6432;User Id=mini;Password=minibank;Database=minibank;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(e => e.ToTable("client"));
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").HasDefaultValue();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.GUID).HasColumnName("guid");    
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

        public Client? GetByUserName(String username)
        {
            using (var db = new ClientRepositoryDbPostgreSQl())
            {
                return db.dbClients
               .FirstOrDefault(item => item.UserName == username);
            }
            //добавить обработку исключения
        }
        public Client? Add(Client item)
        {
            using var db = new ClientRepositoryDbPostgreSQl();
            db.dbClients.Add(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByUserName(item.UserName);
        }
        public Client? Update(Client item)
        {
            using var db = new ClientRepositoryDbPostgreSQl();
            db.dbClients.Update(item);
            db.SaveChanges();
            //добавить обработку исключения
            return GetByUserName(item.UserName);
        }
        public Boolean Remove(Client item)
        {
            using (var db = new ClientRepositoryDbPostgreSQl())
            {
                db.dbClients.Remove(item);
                db.SaveChanges();
            }
            //добавить обработку исключения
            return true;
        }
    }
}