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
    public class Requests
    {
        public RestRequest request;

        public Requests()
        {
            request = new RestRequest(Method.POST);
        }
        public RestRequest getRequest(string token)
        {
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }
        public RestRequest getRequestUpload(string token, string path)
        {
            string jsonHeader = JsonConvert.SerializeObject(new
            {
                path = path,
                mode = "add",
                autorename = true,
                mute = false,
                strict_conflict = false

            });
            request.AddHeader("Dropbox-API-Arg", jsonHeader);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + token);
            return request;
        }

        /*public RestRequest getRequestCheck(string token)
        {
            string jsonHeader = JsonConvert.SerializeObject(new
            {
                include_deleted= false,
                include_has_explicit_shared_members= false,
                include_media_info= false,
                include_mounted_folders= true,
                include_non_downloadable_files= true,
                path="/",
                recursive= false

            });
            //request.AddHeader("Dropbox-API-Arg", jsonHeader);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            return request;
        }*/


    }
}