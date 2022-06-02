using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WebAPi
{
    [TestFixture()]
    public class Test
    {
        static readonly string token = "sl.BIz2xh-nhOuLokf8mL5b-qEX8n7zoYytmKAm5CkdHB0l96HKLmU_I-qbxE8CUhceIosDq2eXBMIqdfjQLlWCe4qzsQINaG6gSavJL1k0Z3wbfQMkNkDEuteso-WKnJBmlitHwv3c2DU";
        public Links link = new Links();
        public string GetIdFile(string file)
        {
            RestClient client =link.getMetadata();           
            Requests experiment=new Requests();
            RestRequest request = experiment.getRequest(token);

            string data = JsonConvert.SerializeObject(new{path = "/" + file});

            string result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            return response["id"];
        }

        [Test()]
        public void Test1Upload()
        {
            string dpPath = "/Image.jpg";
            string pcPath = Directory.GetCurrentDirectory() + "/../../../../Image.jpg";

            RestClient client = link.Upload();
            Requests experiment = new Requests();                           
            RestRequest request = experiment.getRequestUpload(token, dpPath);            

            byte[] data = File.ReadAllBytes(pcPath);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            request.Parameters.Add(body);

            string result = client.Execute(request).Content.ToString();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            Assert.AreEqual(dpPath, response["path_display"]);
        }

        [Test()]
        public void Test2Metadata()
        {
            string file = "Image.jpg";
            var idFile = GetIdFile(file);
            Console.WriteLine(idFile);
            string dropboxPath = "/" + file;
            RestClient client = link.getFileMetadata();          
            Requests experiment = new Requests();
            RestRequest request = experiment.getRequest(token);           

            string data = JsonConvert.SerializeObject(new
            {
                file = idFile,
                actions = new string[] { }
            });

            var result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            Console.WriteLine(result);
            var response = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Console.WriteLine(response["path_display"]);
            Assert.AreEqual(dropboxPath, response["path_display"]);

        }

        [Test()]
        public void Test3Delete()
        {
            string file = "Image.jpg";
            string dropboxPath = "/" + file;

            RestClient client = link.Delete();
            Requests experiment = new Requests();
            RestRequest request = experiment.getRequest(token);

            string data = JsonConvert.SerializeObject(new
            {
                path = dropboxPath
            });

            var result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            Console.WriteLine(result);
            var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(result);
            Console.WriteLine(response);
            Assert.AreEqual(dropboxPath, response["metadata"]["path_display"]);
        }

    }

}