using System;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace minibank_account_api.Models
{
    [Table("account")]
    public class AccountDb
    {
        public AccountDb()
        {

            Id = 0;
            No = String.Empty;
            ClientGuid= new Guid(Guid.NewGuid().ToString());
            Balance = 0;
            Currency = String.Empty;
            
        }
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("no")]
        public string No { get; set; }
        [Column("client_guid")]
        public Guid ClientGuid { get; set; }
        [Column("balance")]
        public decimal Balance { get; set; }
        [Column("currency")]
        public string Currency { get; set; }
     }
}
