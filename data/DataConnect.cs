using DotAgro.Models;
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
        //private const string _url = "http://dotapi.fr:9292/api/";
        private const string _url = "https://localhost:7256/api/";

        public async Task<string?> DataGet(string args)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                var response = await Task.WhenAny(client.GetAsync(args)).Result;
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
                client.BaseAddress = new Uri(_url);
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var rep = await Task.WhenAny(client.PostAsync(args, content)).Result;
                var toto = rep.Content.ReadAsStringAsync().Result;
                return rep;
            }
        }

        public async Task<HttpResponseMessage> DataPut(object item, string args)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var rep = await Task.WhenAny(client.PutAsync(args, content)).Result;
                var toto = rep.Content.ReadAsStringAsync().Result;
                return rep;
            }
        }

        public async Task<HttpResponseMessage> DataDelete(string args, int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                var rep = await Task.WhenAny(client.DeleteAsync($"{args}/{id}")).Result;
                var toto = rep.Content.ReadAsStringAsync().Result;
                return rep;
            }
        }
    }
}
