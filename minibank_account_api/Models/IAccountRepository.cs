using System;

namespace minibank_account_api.Models
{
    public interface IAccountRepository
    {
        IEnumerable<AccountDb> GetByUser(Guid clientguid);
        AccountDb? GetByNo(String no);
        AccountDb? Add(AccountDb item);
        AccountDb? Update(AccountDb item);
        Boolean Remove(AccountDb item);
    }
}
