using System;

namespace minibank_account_api.Models
{
    public class AccountRepository : IAccountRepository
    {
        public Account Add(Account item)
        {
            throw new NotImplementedException();
        }

        public Account GetByNo(string no)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetByUser(Guid clientguid)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string no)
        {
            throw new NotImplementedException();
        }

        public Account Update(Account item)
        {
            throw new NotImplementedException();
        }
    }
}
