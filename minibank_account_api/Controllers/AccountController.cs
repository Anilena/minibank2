using Microsoft.AspNetCore.Mvc;
using minibank_account_api.Models;

namespace minibank_account_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{GUID}", Name = "ReadAccounts")]
        [Produces("application/json")]
        public IEnumerable<Account> GetByUserGuid()
        {
            return Enumerable.Empty<Account>();
        }

        [HttpGet("{no}", Name = "ReadAccountByNo")]
        [Produces("application/json")]
        public Account GetByNo(String no)
        {
            return new Account();
        }

        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Account Set(Account client)
        {
            return new Account();
        }

        [HttpDelete("{no}", Name = "DeleteAccount")]
        [ProducesResponseType(200)]
        public bool Delete(string no)
        {
            return true;
        }
    }
}