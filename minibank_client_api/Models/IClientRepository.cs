using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
