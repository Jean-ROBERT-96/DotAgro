using DotAgro.Models;
using DotAgro.graphics;
using DotAgro.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DotAgro.Data
{
    public class DataConnect : IDataConnect
    {
        private readonly Uri _url = new("http://dotapi:9292/api/");

        public async Task<string?> DataGet(string args)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = _url;
                var response = await client.GetAsync(args);
                if(response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                
                return null;
            }
        }

        public async Task<HttpResponseMessage> DataPost(object item, string args)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = _url;
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                return await client.PostAsync(args, content);
            }
        }

        public async Task<HttpResponseMessage> DataPut(object item, string args)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = _url;
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                return await client.PutAsync(args, content);
            }
        }

        public async Task<HttpResponseMessage> DataDelete(string args, int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = _url;
                return await client.DeleteAsync($"{args}/{id}");
            }
        }
    }
}
