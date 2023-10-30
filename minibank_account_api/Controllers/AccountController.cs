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

        [HttpGet("by-user/{userId}")]
        [Produces("application/json")]
        public IEnumerable<Account> GetByUserGuid([FromRoute] Guid userId)
        {
            return ArraySegment<Account>.Empty;
        }

        [HttpGet("{no}")]
        [Produces("application/json")]
        public Account GetByNo([FromRoute] string no)
        {
            return new Account();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public Account Set([FromBody] Account client)
        {
            return new Account();
        }

        [HttpDelete("{no}")]
        [ProducesResponseType(200)]
        public bool Delete([FromRoute] string no)
        {
            return true;
        }
    }
}