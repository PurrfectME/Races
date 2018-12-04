using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForServices
{
    public interface ICockroachService
    {
        Task Create(Cockroach cockroach);
        Task Delete(Cockroach cockroach);

        Task<List<Cockroach>> GetAllCockroaches();
        //Task AddToRace(Guid raceId);
    }
}
