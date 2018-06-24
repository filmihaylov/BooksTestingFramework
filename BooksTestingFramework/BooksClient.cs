using BooksTestingFramework.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BooksTestingFramework
{
    public class BooksClient
    {

        HttpClient client;

        public BooksClient()
        {
            this.client = new HttpClient();
            this.client.Timeout = new TimeSpan(0, 0, 20);
            this.client.BaseAddress = new Uri(Endpoints.BaseEndpoint);
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //this constructor adds retry logic if needed   
        public BooksClient(int retries)
        {
            this.client = new HttpClient(new RetryHandler(new HttpClientHandler(), retries));
            this.client.Timeout = new TimeSpan(0, 0, 20);
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> Post(string requestUri, object data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await this.client.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> Get(string requestUri)
        {
            return await this.client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> Put(string requestUri, object data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await this.client.PutAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> Delete(string requestUri)
        {
            return await this.client.DeleteAsync(requestUri);
        }
    }
}