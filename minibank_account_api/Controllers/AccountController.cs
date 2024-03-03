using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

       
        [HttpGet("by-user/{userId}")]
        [Produces("application/json")]
        public IEnumerable<Account> GetByUserGuid([FromRoute] Guid userId)
        {
            List<Account> accounts = new List<Account>();
            IEnumerable<AccountDb> accountsDb = new AccountRepositoryDbPostgreSQL(_connectionString).GetByUser(userId);

            foreach (var item in accountsDb)
            {
                accounts.Add(new Account().ConvertToObj(item));
            }
            return accounts;
        }

        [HttpGet("{no}")]
        [Produces("application/json")]
        public Account GetByNo([FromRoute] string no)
        {
            return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString).GetByNo(no));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Account Set([FromBody] Account account)
        {
            if (account.No == "")
            {
                account.No = AccountController.GetAccNo(account.Currency);
                return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString).Add(new Account().ConvertToDb(account))) ?? new Account();
            }
            return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString).Update(new Account().ConvertToDb(account))) ?? new Account();
        }

        [HttpDelete("{no}")]
        [ProducesResponseType(200)]
        public bool Delete([FromRoute] string no)
        {
            return new AccountRepositoryDbPostgreSQL(_connectionString).Remove(new Account().ConvertToDb(new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL(_connectionString).GetByNo(no))));
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