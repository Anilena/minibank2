using System;
using System.ComponentModel.DataAnnotations;

namespace minibank_account_api.Models
{
    public class Account
    {
        public Account()
        {
            Id = 0;
            No = String.Empty;
            ClientGuid= new Guid(Guid.NewGuid().ToString());
            Balance = 0;
            Currency = String.Empty;
            
        }
        public int Id { get; set; }
        public string No { get; set; }
        public Guid ClientGuid { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        //Конвертация из БД объекта
        public Account ConvertToObj(AccountDb? accountDb)
        {
            var account = new Account();
            if (accountDb != null)
            {
                account.Id = accountDb.Id;
                account.No = accountDb.No;
                account.ClientGuid = accountDb.ClientGuid;
                account.Balance = accountDb.Balance;
                account.Currency = accountDb.Currency;
             }
            return account;
        }
        //Конвертация в БД объект
        public AccountDb ConvertToDb(Account account)
        {
            var accountDb = new AccountDb();
            accountDb.Id = account.Id;
            accountDb.No = account.No;
            accountDb.ClientGuid = account.ClientGuid;
            accountDb.Balance = account.Balance;
            accountDb.Currency = account.Currency;
            return accountDb;
        }
    }
}
