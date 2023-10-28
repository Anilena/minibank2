using System;

namespace minibank_client_api.Models
{
    public interface IClientRepository
    {
        IEnumerable<Client> Get();
        Client GetByUserName(String username);
        Client Add(Client item);
        Boolean Remove(Guid GUID);
        Client Update(Client item);
    }
}
