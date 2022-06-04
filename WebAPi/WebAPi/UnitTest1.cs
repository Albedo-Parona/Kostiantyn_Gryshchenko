using Newtonsoft.Json;
using NUnit.Framework;
using System;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;




namespace WebAPI
{
    [TestFixture()]
    public class Test
    {
        
        static readonly string token = "sl.BI7jixDi-3Loo47G_kpza0_wZrrF_m6YM-CzHEYVieMahs8bsCBPc3uiPcM4Wvd_TxsADzsJhWfG0E34GDN1qTjXXREC-ucZCugUHj2y9mfR0PMFcroyYx71xyBs2JJyhr81ZzRrMM0";
        public Links link = new Links();
        public string GetIdFile(string file)
        {
            RestClient client = link.getMetadata();
            Requests experiment = new Requests();
            RestRequest request = experiment.getRequest(token);

            string data = JsonConvert.SerializeObject(new
            {
                path = "/" + file
            });
            string result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            return response["id"];
        }

        [Test, Order(1)]
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
            //Check file downloaddong with Metadata
            RestClient clientCheck = link.getFileMetadata();
            Requests experimentCheck = new Requests();
            RestRequest requestCheck = experimentCheck.getRequest(token);
            string file = "Image.jpg";
            var idFile = GetIdFile(file);

            string dataCheck = JsonConvert.SerializeObject(new
            {
                file = idFile,
                actions = new string[] { }
            });

            var resultCheck = client.Execute(request.AddJsonBody(dataCheck)).Content.ToString();
            Console.WriteLine(result);
            var responseCheck = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultCheck);
            Console.WriteLine(responseCheck["path_display"]);
            //End check

            Assert.AreEqual(dpPath, response["path_display"]);
        }

        [Test, Order(2)]
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
            //Check with name and path
            object[] DPinfo = { response["name"], response["path_display"] };
            string[] PCinfo = { file, dropboxPath };
            Assert.AreEqual(PCinfo, DPinfo);

        }

        [Test, Order(3)]
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
            //Check deleteing with metadata
            try
            {

                var idFile = GetIdFile(file);
                Console.WriteLine(idFile);

                RestClient client1 = link.getFileMetadata();
                Requests experiment1 = new Requests();
                RestRequest request1 = experiment.getRequest(token);

                string data1 = JsonConvert.SerializeObject(new
                {
                    file = idFile,
                    actions = new string[] { }
                });

                var result1 = client.Execute(request.AddJsonBody(data1)).Content.ToString();
                Console.WriteLine(result);
                var response1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(result1);
                Console.WriteLine(response["path_display"]);                
                object[] DPinfo = { response1["name"], response1["path_display"] };
                string[] PCinfo = { file, dropboxPath };
                

            }
            catch
            {
                Console.WriteLine("File was deleted");
            }



        }

    }
}