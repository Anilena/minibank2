using System;

namespace minibank_client_api.Models
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client Get(Guid GUID);
        Client Add(Client item);
        void Remove(Guid GUID);
        bool Update(Client item);
    }
}
