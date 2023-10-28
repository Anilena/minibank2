using System;
using System.ComponentModel.DataAnnotations;

namespace minibank_client_api.Models
{
	public class Client
	{
		public Client()
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

        public int Id { get; set; }
        public Guid GUID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
