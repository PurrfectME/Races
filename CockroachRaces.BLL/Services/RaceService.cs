using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;
using CockroachRaces.BLL.InterfaceForServices;

namespace CockroachRaces.BLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRaceFinder _finder;
        private readonly IRepository<Race> _repository;


        public RaceService(IUnitOfWork unitOfWork, IRaceFinder finder, IRepository<Race> repository)
        {
            _unitOfWork = unitOfWork;
            _finder = finder;
            _repository = repository;
        }

        public async Task Create(Race race)
        {
            
            _repository.Create(race);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Race race)
        {
            _repository.Delete(race);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Race race)
        {
            _repository.Update(race);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Race>> GetAllRaces()
        {
            return await _finder.FindAllRaces();
        }

        public async Task<List<Race>> GetActiveRaces()
        {
            return await _finder.FindActiveRaces();
        }
    }
}
