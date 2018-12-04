using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;
using CockroachRaces.BLL.InterfaceForServices;

namespace CockroachRaces.BLL.Services
{
    public class CockroachService : ICockroachService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICockroachFinder _finder;
        private readonly IRepository<Cockroach> _repository;


        public CockroachService(IUnitOfWork unitOfWork, ICockroachFinder finder, IRepository<Cockroach> repository)
        {
            _unitOfWork = unitOfWork;
            _finder = finder;
            _repository = repository;
        }


        public async Task Create(Cockroach cockroach)
        {
            cockroach.Id = Guid.NewGuid();
            _repository.Create(cockroach);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Cockroach cockroach)
        {
            _repository.Delete(cockroach);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Cockroach>> GetAllCockroaches()
        {
            return await _finder.FindAllCockroaches();
        }

        //public Task AddToRace(Guid raceId)
        //{
            
        //}
    }
}
