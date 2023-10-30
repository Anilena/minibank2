using System.ComponentModel.DataAnnotations.Schema;

namespace minibank_client_api.Models
{
    //Основной класс.               
    public class Client
    {
        public Client()
        {
            Id = 0;
            GUID = new Guid(Guid.NewGuid().ToString());
            FirstName = String.Empty;
            SecondName = String.Empty;
            LastName = String.Empty;
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

        //Конвертация из БД объекта
        public Client ConvertToObj(ClientDb? clientDb)
        {
            var client = new Client();
            if (clientDb != null)
            {
                client.Id = clientDb.Id;
                client.GUID = clientDb.GUID;
                client.FirstName = clientDb.FirstName;
                client.SecondName = clientDb.SecondName;
                client.LastName = clientDb.LastName;
                client.Email = clientDb.Email;
                client.UserName = clientDb.UserName;
                client.Password = clientDb.Password;
            }
            return client;
        }
        //Конвертация в БД объект
        public ClientDb ConvertToDb(Client client)
        {
            var clientDb = new ClientDb();
            clientDb.Id = client.Id;
            clientDb.GUID = client.GUID;
            clientDb.FirstName = client.FirstName;
            clientDb.SecondName = client.SecondName;
            clientDb.LastName = client.LastName;
            clientDb.Email = client.Email;
            clientDb.UserName = client.UserName;
            clientDb.Password = client.Password;
            return clientDb;
        }
    }
}
