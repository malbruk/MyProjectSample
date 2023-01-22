using Microsoft.AspNetCore.Mvc;
using MyProject.API.Models;
using MyProject.Common.DTOs;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using MyProject.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Grpc.Net.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<List<RoleDTO>> Get()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7002");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });

            //new AuthorizationRequest { UserId = 1, Permission = "VIEW_ALL_STUDENTS" });
            return await _roleService.GetListAsync();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> Get(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role is null)
            {
                return NotFound();
            }
            return role;
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> Post([FromBody] RolePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _roleService.AddAsync(new RoleDTO { Name = model.Name, Title = model.Description });

        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoleDTO>> Put(int id, [FromBody] RolePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _roleService.UpdateAsync(new RoleDTO { Id = id, Name = model.Name, Title = model.Description });
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
