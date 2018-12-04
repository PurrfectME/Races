using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForServices
{
    public interface IBetService
    {
        Task Create(Bet bet);
        Task Delete(Bet bet);

        //Task<Bet> PlaceBet(User user);
        Task<List<Bet>> GetAllBets();
        Task<List<Bet>> GetBetByUser(Guid userId);
        Task<List<Bet>> GetOpenBets();
        Task<List<Bet>> GetBetByRace(Guid raceId);
        
    }
}
