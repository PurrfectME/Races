using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForFinders
{
    public interface ICockroachFinder : IFinder<Cockroach>
    {
        Task<List<Cockroach>> FindAllCockroaches();
        
    }
}
