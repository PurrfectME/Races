using System;
using System.Threading.Tasks;
using System.Web.Http;
using CockroachRaces.BLL.Entities;
using CockroachRaces.Managers;
using CockroachRaces.Models;
using Microsoft.AspNet.Identity;

namespace CockroachRaces.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ApplicationUserManager _manager;

        public AccountController(ApplicationUserManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("Account/Register")]
        public async Task<IHttpActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            var userToRegister = new User
                {Email = model.Email, Id = Guid.NewGuid(), Balance = 100, UserName = model.Email};

            var result = await _manager.CreateAsync(userToRegister, model.Password);
            await _manager.AddToRoleAsync(userToRegister.Id, "User");

            var role = await _manager.GetRolesAsync(userToRegister.Id);

            var tuple = (result, role);

            return Ok(tuple);
        }

        [HttpGet]
        [Route("Account/GetRole")]
        public async Task<IHttpActionResult> GetRole()
        {
            var userId = new Guid(User.Identity.GetUserId());

            var result = await _manager.GetRolesAsync(userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
