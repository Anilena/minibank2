using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace minibank_web.Models
{
    public class AccountRepositoryAPI : IAccountRepository
    {
        public Account Accounts { get; set; }

        public IEnumerable<Account> GetByUser(Guid clientguid)
        {
            return new ArraySegment<Account>();
        }

        public Account GetByNo(string no)
        {
            return new Account();
        }
        public Account Add(Account item)
        {
            return new Account();
        }

        public Account Update(Account item)
        {
            return new Account();
        }
        public bool Remove(Account item)
        {
           return true;
        }
    }
}
