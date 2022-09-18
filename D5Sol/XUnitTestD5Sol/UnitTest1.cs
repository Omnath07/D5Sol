using System;
using System.Collections.Generic;
using Xunit;
using D5Sol;
using DataLayer.Models;
using D5Sol.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using D5Sol.Controllers;
using D5Sol.Repository;

namespace XUnitTestD5Sol
{
    public class UnitTest1
    {
    
       

        


        [Fact]
        public async void Task_GetPosts_Return_OkResult()
        {
            ////Arrange  
            //var controller = _service.GetAll().ToList();
            //var postId = 2;

            ////Act  
            //var data = await controller.GetAll(postId);

            ////Assert  
            //Assert.IsType<OkObjectResult>(controller);
        }
    }
}
