using System;

namespace minibank_web.Models
{
    public interface IClientRepository
    {
        Client GetByUserName(String username);
        Client Add(Client item);
        Client Update(Client item);
        Boolean Remove(Client item);
    }
}
