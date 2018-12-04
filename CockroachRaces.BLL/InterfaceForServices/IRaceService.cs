using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForServices
{
    public interface IRaceService
    {
        Task Create(Race race);
        Task Delete(Race race);
        Task Update(Race race);

        Task<List<Race>> GetAllRaces();
        Task<List<Race>> GetActiveRaces();
    }
}
