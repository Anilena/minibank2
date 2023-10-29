using Microsoft.AspNetCore.Mvc;
using minibank_client_api.Models;

namespace minibank_client_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{UserName}", Name = "ReadClientByUserName")]
        [Produces("application/json")]
        public Client GetByUserName(String username)
        {
            return new ClientRepositoryDbPostgreSQl().GetByUserName(username)?? new Client();
        }

        [HttpPut(Name = "UpdateOrCreateClient")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Client Set(Client client)
        {
            if (client.Id == 0) {
                return new ClientRepositoryDbPostgreSQl().Add(client) ?? new Client();
            }
            return new ClientRepositoryDbPostgreSQl().Update(client) ?? new Client();
        }

        [HttpDelete("{GUID}", Name = "DeleteClient")]
        [ProducesResponseType(200)]
        public bool Delete(Client client)
        {
            return new ClientRepositoryDbPostgreSQl().Remove(client);
        }
    }
}