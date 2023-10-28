using System;

namespace minibank_client_api.Models
{
	public class Client
	{
		public Client()
		{
		}

        public int Id { get; set; }

        public Guid GUID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public decimal LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
