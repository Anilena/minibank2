using System;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace minibank_client_api.Models
{
    [Table("client")]
	public class ClientDb: DbContext
	{
		public ClientDb()
		{
            Id = 0;
            GUID = new Guid(Guid.NewGuid().ToString());
            FirstName= String.Empty;
            SecondName= String.Empty;
            LastName= String.Empty;
            Email = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;
		}
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("guid")]
        public Guid GUID { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("second_name")]
        public string SecondName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
