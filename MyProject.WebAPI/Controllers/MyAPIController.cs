using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyAPIController : ControllerBase
    {
        [HttpGet]
        public string GetAllObjects()
        {
            return "all objects"; 
        }

        [HttpPost]
        public string AddObject(string name)
        {
            return $"object with name {name} was added!";
        }


        [HttpPut]
        public string UpdateObject(int id, string name)
        {
            return $"object with id {id} was updated to name {name}!";
        }

        [HttpDelete]
        public string RemoveObject(int id)
        {
            return $"object with id {id} was deleted!";
        }
    }
}
