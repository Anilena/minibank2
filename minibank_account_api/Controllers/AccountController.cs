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

        [HttpGet(Name = "ReadAccountByNo")]
        [Produces("application/json")]
        public Account GetByNo(String no)
        {
            return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL().GetByNo(no));
        }

        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Account Set(Account account)
        {
            if (account.Id == 0)
            {
                return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL().Add(new Account().ConvertToDb(account))) ?? new Account();
            }
            return new Account().ConvertToObj(new AccountRepositoryDbPostgreSQL().Update(new Account().ConvertToDb(account))) ?? new Account();
        }

        [HttpDelete(Name = "DeleteAccount")]
        [ProducesResponseType(200)]
        public bool Delete(Account account)
        {
            return new AccountRepositoryDbPostgreSQL().Remove(new Account().ConvertToDb(account));
        }
    }
}