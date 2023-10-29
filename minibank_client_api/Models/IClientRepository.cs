using System;

namespace minibank_client_api.Models
{
    public interface IClientRepository
    {
        Client? GetByUserName(String username);
        Client? Add(Client item);
        Client? Update(Client item);
        Boolean Remove(Client item);
    }
}
