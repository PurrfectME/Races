using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CockroachRaces.BLL.Entities;
using CockroachRaces.Managers;
using CockroachRaces.Models;

namespace CockroachRaces.Areas.Admin.Controllers
{
    public class AdminController : ApiController
    {
        private readonly ApplicationUserManager _manager;


        public AdminController(ApplicationUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("Admin/AllUsers/")]
        public IHttpActionResult AllUsers()
        {
            var usersList = _manager.Users;
            IList<string> rolesList = new List<string>();

            foreach (var item in usersList)
            {
                var temp = item.Roles;

                foreach (var role in temp)
                {
                    rolesList.Add(role.RoleId.ToString());
                }
            }

            (IList<string>, IQueryable<User>) tuple = (rolesList, usersList);

            return Ok(tuple);
        }

        [HttpPost]
        [Route("Admin/ChangeCredentials")]
        public async Task<IHttpActionResult> ChangeCredentials(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var user = new User { Email = model.Email, UserName = model.Email, PasswordHash = "AMBSPHWz0xW6nYuGPmyoR9pKqTTO3hfO3WQ1cWy2GMPrJRMczZf9YN/hMSOFi73y6g==", Id = new Guid("E51082BA-BB2A-4FC3-A31E-607F86516311"), SecurityStamp = "f82a47af-2337-4c28-b628-0f3f53e4e8f2" };

            var result = await _manager.UpdateAsync(user);

            var concreteUser = await _manager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (concreteUser != null)
            {
                await _manager.RemoveFromRoleAsync(concreteUser.Id, "User");
                await _manager.AddToRoleAsync(concreteUser.Id, model.Role);

            }

            return Ok(result);
        }



    }
}
