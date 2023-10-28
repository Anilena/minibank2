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

        [HttpGet(Name = "ReadClients")]
        [Produces("application/json")]
        public IEnumerable<Client> Get()
        {
            return Enumerable.Empty<Client>();
        }

        [HttpGet("{UserName}", Name = "ReadClientByUserName")]
        [Produces("application/json")]
        public Client GetByUserName(String username)
        {
            return new Client();
        }

        [HttpPut(Name = "UpdateClient")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Client Set(Client client)
        {
            return new Client();
        }

        [HttpDelete("{GUID}", Name = "DeleteClient")]
        [ProducesResponseType(200)]
        public bool Delete(Guid guid)
        {
            return true;
        }
    }
}