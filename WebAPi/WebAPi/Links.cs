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

namespace WebAPI
{
    public class Links
    {

        public Links()
        {

        }

        public RestClient getMetadata()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            return client;
        }

        public RestClient Upload()
        {
            RestClient client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            
            return client;
        }

        public RestClient getFileMetadata()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            return client;
        }

        public RestClient Delete()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            return client;
        }
        public RestClient CheckExist()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/files/list_folder");
            return client;
        }
    }
}