using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForServices
{
    public interface IUserService
    {
        Task Create(User user);
        Task Delete(User user);

        Task<List<User>> FindAllUsers();
    }
}
