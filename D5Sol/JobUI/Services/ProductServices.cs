using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JobUI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient httpClient;
        public ProductServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<jobs>> CreateSJob(jobs hero)
        {
            var result = await httpClient.PostAsJsonAsync("api/jobs/AddJob", hero);
          
            return null;
        }

        public async Task<List<jobs>> DeeteJob(int id)
        {
            var result = await httpClient.DeleteAsync("api/jobs/" + id);
            return null;
        }

        public async Task<List<jobs>> EditJob(jobs hero)
        {
            int id = hero.Id;
             await httpClient.PutJsonAsync("api/jobs/" + id,hero);
            return null;
        }

        public async Task<IEnumerable<jobs>> getAllProduct()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<jobs>>("api/jobs");
        }
       
      
       

        public async Task<List<jobs>> getJobId(string id)
        {
            return await httpClient.GetJsonAsync<List<jobs>>("api/jobs");
       
        }
    }
}
