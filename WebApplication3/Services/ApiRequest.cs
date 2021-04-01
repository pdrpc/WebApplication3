﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication3.Services
{
    public static class ApiRequest
    {
        public static string BaseUrl = "http://viacep.com.br/ws/";

        public static async Task<Endereco> SendAsync(string Url) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(Url);

                if (response.IsSuccessStatusCode)
                {
                    var dataResponse = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Endereco>(dataResponse);
                }
                else {
                    return new Endereco();
                }
            }
        }
    }
}