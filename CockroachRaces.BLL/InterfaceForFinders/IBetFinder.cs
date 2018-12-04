using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.BLL.InterfaceForFinders
{
    public interface IBetFinder : IFinder<Bet>
    {
        Task<List<Bet>> FindAllBets();
        Task<List<Bet>> FindBetByUser(Guid userId);
        Task<List<Bet>> FindOpenBets();
        Task<List<Bet>> FindBetByRace(Guid raceId);
    }
}
