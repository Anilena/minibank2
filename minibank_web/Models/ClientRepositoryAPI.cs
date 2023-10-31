using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.IO;
using System.Net;

namespace minibank_web.Models
{
    public class ClientRepositoryAPI : IClientRepository
    {
        public Client Client { get; set; }

        private const string URL = "http://http://84.201.172.238:9082/Client";
        private const string DATA = @"{""id"":""{}"", }";

   //{
  //"id": 0,
  //"guid": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  //"firstName": "string",
  //"secondName": "string",
  //"lastName": "string",
  //"email": "string",
  //"userName": "string",
  //"password": "string"
  //}


    static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(DATA);
            requestWriter.Close();

            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
            }
            catch (Exception e)
            {
                
            }
            //client.Dispose();
        }

        public Client GetByUserName(String username)
        {
            return new Client();
        }
        public Client Add(Client item)
        {
            return new Client();
        }
        public Client Update(Client item)
        {
            return new Client();
        }
        public Boolean Remove(Client item)
        {
            return true;
        }
    }
}