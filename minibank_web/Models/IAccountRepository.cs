using System;
using System.Collections.Generic;

namespace minibank_web.Models
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetByUser(Guid clientguid);
        Account GetByNo(String no);
        Account Add(Account item);
        Account Update(Account item);
        Boolean Remove(Account item);
    }
}
