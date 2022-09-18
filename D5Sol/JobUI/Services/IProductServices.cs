using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace JobUI.Services
{
    public interface IProductServices
    {


        Task<IEnumerable<jobs>> getAllProduct();
        Task<List<jobs>> CreateSJob(jobs hero);
        Task<List<jobs>> DeeteJob(int id);
        Task<List<jobs>> getJobId(string id);
        Task<List<jobs>> EditJob(jobs hero);
    }
}
