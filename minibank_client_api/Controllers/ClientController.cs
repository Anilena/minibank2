using Microsoft.AspNetCore.Mvc;
using minibank_client_api.Models;

namespace minibank_client_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IConfiguration _config;
        private string? _connectionString;

        public ClientController(ILogger<ClientController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _connectionString = _config.GetConnectionString("SQLConnection");
        }

        [HttpGet("{username}")]
        [Produces("application/json")]
        public Client GetByUserName([FromRoute]String username)
        {
#if DEBUG
            _logger.LogInformation("GetByUserName");
            _logger.LogInformation(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _config.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FolderPath").Value ?? ""));
#endif
            try
            {
                return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).GetByUserName(username));
            }
            catch (Exception e) { _logger.LogError("GetByUserName" + e.Message); }

            return new Client();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Client Set([FromBody]Client client)
        {
#if DEBUG
            _logger.LogInformation("Set");
#endif
            if (client.Id == 0) {
                try {
                    client.GUID = new Guid();
                    return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).Add(new Client().ConvertToDb(client))) ?? new Client();
                }
                catch (Exception e) { _logger.LogDebug("Set.Id=0"+e.Message); }
            }
            try
            {
                return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).Update(new Client().ConvertToDb(client))) ?? new Client();
            }
            catch (Exception e) { _logger.LogDebug("Set.Id=" + client.Id.ToString() + e.Message); }

            return new Client();
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(200)]
        public bool Delete([FromRoute] string username)
        {
#if DEBUG
            _logger.LogInformation("Delete");
#endif
            try
            {
                return new ClientRepositoryDbPostgreSQl(_connectionString, _logger).Remove(new Client().ConvertToDb(new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).GetByUserName(username))));
            }
            catch (Exception e) { _logger.LogDebug("Delete"+e.Message); }

            return false;
        }
    }
}