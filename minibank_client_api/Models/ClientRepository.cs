using System;

namespace minibank_client_api.Models
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> clients = new List<Client>();
        

        public ClientRepository()
        {
           // Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
           // Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
           // Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        public IEnumerable<Client> Get()
        {
            return clients;
        }

        public Client GetByUserName(String username)
        {
            return new Client();
        }

        public Client Add(Client item)
        {
            return new Client();
        }

        public Boolean Remove(Guid GUID)
        {
            return true;
        }

        public Client Update(Client item)
        {
           return new Client();
        }
    }
}