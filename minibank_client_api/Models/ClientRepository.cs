using System;

namespace minibank_client_api.Models
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> clients = new List<Client>();
        private int _nextId = 1;

        public ClientRepository()
        {
           // Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
           // Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
           // Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        public IEnumerable<Client> GetAll()
        {
            return clients;
        }

        public Client Get(Guid GUID)
        {
            return clients.Find(p => p.GUID == GUID);
        }

        public Client Add(Client item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            clients.Add(item);
            return item;
        }

        public void Remove(Guid GUID)
        {
            clients.RemoveAll(p => p.GUID == GUID);
        }

        public bool Update(Client item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = clients.FindIndex(p => p.GUID == item.GUID);
            if (index == -1)
            {
                return false;
            }
            clients.RemoveAt(index);
            clients.Add(item);
            return true;
        }
    }
}