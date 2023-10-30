using System;

namespace minibank_client_api.Models
{
    public interface IClientRepository
    {
        ClientDb? GetByUserName(String username);
        ClientDb? Add(ClientDb item);
        ClientDb? Update(ClientDb item);
        Boolean Remove(ClientDb item);
    }
}
