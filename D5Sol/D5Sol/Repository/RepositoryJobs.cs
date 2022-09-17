using D5Sol.Interface;
using DataLayer.Data;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D5Sol.Repository
{
    public class RepositoryJobs : IRepository<jobs>
    {

        ApplicationDbContext _dbContext;
        public RepositoryJobs(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public Task<jobs> CreateJob(jobs _object)
        {
            var obj = _dbContext.Jobs.AddAsync(_object);
            _dbContext.SaveChanges();
            return null;
        }

       

        
        public IEnumerable<jobs> GetAll()
        {
            try
            {
                return _dbContext.Jobs.ToList();
            }
            catch 
            {
                throw;
            }
        }


        public jobs GetById(int Id)
        {
            return _dbContext.Jobs.Where(x =>  x.Id == Id).FirstOrDefault();
        }

        public void UpdateJob(jobs _object)
        {
            var DataList = _dbContext.Jobs.Where(x => x.Id == _object.Id).FirstOrDefault();
            _dbContext.Jobs.Update(DataList);
            _dbContext.SaveChanges();
        }

        //Delete Person  
        void IRepository<jobs>.DeleteJob(jobs _object)
        {
            try
            {
                var DataList = _dbContext.Jobs.Where(x => x.Id == _object.Id).FirstOrDefault();

                _dbContext.Remove(DataList);

            }
            catch (Exception)
            {
            }
        }
    }
}
