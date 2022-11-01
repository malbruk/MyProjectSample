using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Models;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public List<RoleModel> Get()
        {
            return _roleService.GetList();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public RoleModel Get(int id)
        {
            return _roleService.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //TODO send email to admin
            
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
