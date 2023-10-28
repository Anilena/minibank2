using System;

namespace minibank_account_api.Models
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetByUser(Guid clientguid);
        Account GetByNo(String no);
        Account Add(Account item);
        Boolean Remove(String no);
        Account Update(Account item);
    }
}
