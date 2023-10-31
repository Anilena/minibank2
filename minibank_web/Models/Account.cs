using System;
using System.ComponentModel.DataAnnotations;

namespace minibank_web.Models
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
    }
}
