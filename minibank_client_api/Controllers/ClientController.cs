using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using minibank_client_api.Helpers;
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

        [FeatureGate(FeatureFlags.GetByUserName)]
        [HttpGet("{username}")]
        [Produces("application/json")]
        public Client? GetByUserName([FromRoute]String username)
        {
#if DEBUG
            _logger.LogInformation("GetByUserName");
#endif
            try
            {
                //нужно изменить, что бы в этой ветке возвращался null, если ошибка глубже.
                return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).GetByUserName(username));
            }
            catch (Exception e) { _logger.LogError("GetByUserName" + e.Message); }

            return null;
        }

        [FeatureGate(FeatureFlags.Set)]
        [HttpPut]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Client? Set([FromBody]Client client)
        {
#if DEBUG
            _logger.LogInformation("Set");
#endif
            if (client.Id == 0) {
                try {
                    client.GUID = new Guid();
                    return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).Add(new Client().ConvertToDb(client))) ?? new Client();
                }
                catch (Exception e) { _logger.LogError("Set.Id=0"+e.Message); }
            }
            try
            {
                return new Client().ConvertToObj(new ClientRepositoryDbPostgreSQl(_connectionString, _logger).Update(new Client().ConvertToDb(client))) ?? new Client();
            }
            catch (Exception e) { _logger.LogError("Set.Id=" + client.Id.ToString() + e.Message); }

            return null;
        }

        [FeatureGate(FeatureFlags.Delete)]
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
            catch (Exception e) { _logger.LogError("Delete"+e.Message); }

            return false;
        }
    }
}