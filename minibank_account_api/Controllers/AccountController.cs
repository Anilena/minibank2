using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement.Mvc;
using minibank_account_api.Helpers;
using minibank_account_api.Models;

namespace minibank_account_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private IConfiguration _config;
        private string? _connectionString;

        public AccountController(ILogger<AccountController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _connectionString = _config.GetConnectionString("SQLConnection");
        }

        [FeatureGate(FeatureFlags.GetByUserGuid)]
        [HttpGet("by-user/{userId}")]
        [Produces("application/json")]
        public IEnumerable<Account> GetByUserGuid([FromRoute] Guid userId)
        {
#if DEBUG
            _logger.LogInformation("GetByUserGuid");
#endif
            List<Account> accounts = new List<Account>();
            try
            {
                IEnumerable<AccountDb> accountsDb = new AccountRepositoryDbPostgreSQL(_connectionString, _logger).GetByUser(userId);

                foreach (var item in accountsDb)
                {
                    accounts.Add(new Account().ConvertToObj(item));
                }
            }
            catch (Exception e) { _logger.LogError("GetByUserGuid" + e.Message); }
            return accounts;
        }

        [FeatureGate(FeatureFlags.GetByNo)]
        [HttpGet("{no}")]
        [Produces("application/json")]
        public Account? GetByNo([FromRoute] string no)
        {
#if DEBUG
            _logger.LogInformation("GetByNo");
#endif
            try
            {
                return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString, _logger).GetByNo(no));
            }
            catch (Exception e) { _logger.LogError("GetByNo" + e.Message); }
            return null;
        }

        [FeatureGate(FeatureFlags.Set)]
        [HttpPut]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Account? Set([FromBody] Account account)
        {
#if DEBUG
            _logger.LogInformation("Set");
#endif
            try
            {
                if (account.No == "")
                {
                    account.No = AccountController.GetAccNo(account.Currency);
                    return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString, _logger).Add(new Account().ConvertToDb(account))) ?? new Account();
                }
                return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString, _logger).Update(new Account().ConvertToDb(account))) ?? new Account();
            }
            catch (Exception e) { _logger.LogError("Set" + e.Message); }
            return null;
        }

        [FeatureGate(FeatureFlags.Delete)]
        [HttpDelete("{no}")]
        [ProducesResponseType(200)]
        public bool Delete([FromRoute] string no)
        {
#if DEBUG
            _logger.LogInformation("Delete");
#endif
            try
            {
                return new AccountRepositoryDbPostgreSQL(_connectionString, _logger).Remove(new Account().ConvertToDb(new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString, _logger).GetByNo(no))));
            }
            catch (Exception e) { _logger.LogError("Delete" + e.Message); }
            return false;
        }

        private static String GetAccNo(String currency)
        {
            Dictionary<string, string> _currency;
            _currency = new Dictionary<string, string>()
            {
                {"RUR", "810"},
                {"EUR", "978"},
                {"USD", "840"}
            };

            return "40817" + _currency.FirstOrDefault(e => e.Key == currency).Value + AccountController.RandomDigits(12);
        }

        private static string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}