using D5Sol.Interface;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace D5Sol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IRepository<jobs> _Jobs;

        public EmployeeController(IRepository<jobs> Jobs)
        {
            _Jobs = Jobs;

        }



        //GET All Person  
        [HttpGet("GetAll")]
        public ActionResult GetAllPersons()
        {
            var data = _Jobs.GetAll();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return null;
        }





    }
}
