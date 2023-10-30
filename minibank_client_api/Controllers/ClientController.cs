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

        [HttpGet(Name = "ReadClientByUserName")]
        [Produces("application/json")]
        public Client GetByUserName(String username)
        {
            return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl().GetByUserName(username));
        }

        [HttpPut(Name = "UpdateOrCreateClient")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Client Set(Client client)
        {
            if (client.Id == 0) {
                client.GUID = new Guid();
                return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl().Add(new Client().ConvertToDb(client))) ?? new Client();
            }
            return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl().Update(new Client().ConvertToDb(client))) ?? new Client();
        }

        [HttpDelete(Name = "DeleteClient")]
        [ProducesResponseType(200)]
        public bool Delete(Client client)
        {
            return new ClientRepositoryDbPostgreSQl().Remove(new Client().ConvertToDb(client));
        }
    }
}