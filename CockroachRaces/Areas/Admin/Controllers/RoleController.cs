using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using CockroachRaces.BLL.Entities;
using CockroachRaces.Managers;
using CockroachRaces.Models;

namespace CockroachRaces.Areas.Admin.Controllers
{
    public class RoleController : ApiController
    {
        //[Authorize(Roles = "Admin")]
        public class RolesController : ApiController
        {
            private readonly ApplicationRoleManager _manager;


            public RolesController(ApplicationRoleManager manager)
            {
                _manager = manager;
            }


            [HttpPost]
            [Route("Admin/Role/Create/")]
            public async Task<IHttpActionResult> Create(RoleModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var roleToAdd = new Role {Id = Guid.NewGuid(), Name = model.Name};

                await _manager.CreateAsync(roleToAdd);

                return Ok(roleToAdd);
            }

            [HttpGet]
            [Route("Admin/Role/All/")]
            public async Task<IHttpActionResult> All()
            {
                var allRoles = await _manager.Roles.ToListAsync();

                return Ok(allRoles);
            }
        }
    }
}
