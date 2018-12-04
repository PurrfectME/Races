using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;
using CockroachRaces.BLL.InterfaceForServices;

namespace CockroachRaces.BLL.Services
{
    public class BetService : IBetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBetFinder _finder;
        private readonly IRepository<Bet> _repository;


        public BetService(IUnitOfWork unitOfWork, IBetFinder finder, IRepository<Bet> repository)
        {
            _unitOfWork = unitOfWork;
            _finder = finder;
            _repository = repository;
        }



        public async Task Create(Bet bet)
        {
            bet.Id = Guid.NewGuid();
            _repository.Create(bet);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Bet bet)
        {
            _repository.Delete(bet);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Bet>> GetAllBets()
        {
            return await _finder.FindAllBets();
        }

        public async Task<List<Bet>> GetBetByUser(Guid userId)
        {
            return await _finder.FindBetByUser(userId);
        }

        public async Task<List<Bet>> GetOpenBets()
        {
            return await _finder.FindOpenBets();
        }

        public async Task<List<Bet>> GetBetByRace(Guid raceId)
        {
            return await _finder.FindBetByRace(raceId);
        }
    }
}
