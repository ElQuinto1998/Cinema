using Newtonsoft.Json;
using Practica.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Practica.Helpers
{
    public static class ApiHelper
    {

        private static string uriBase = "https://misapis.azurewebsites.net";
        public static T Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uriBase);

            var request = client.GetAsync(url).Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<T>(responseJson);

                return response;
            }

            return default(T);

        }

        public static T Post<T>(string url, Usuarios usuario)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uriBase);

            var json = JsonConvert.SerializeObject(usuario);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = client.PostAsync(url, stringContent).Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<T>(responseJson);

                return response;
            }

            return default(T);

        }

    }
}
