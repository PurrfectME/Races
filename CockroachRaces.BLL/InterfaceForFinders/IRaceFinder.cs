using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForFinders
{
    public interface IRaceFinder : IFinder<Race>
    {
        Task<List<Race>> FindAllRaces();
        Task<List<Race>> FindActiveRaces();
    }
}
