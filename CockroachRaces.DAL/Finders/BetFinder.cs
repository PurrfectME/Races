using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;

namespace CockroachRaces.DAL.Finders
{
    public class BetFinder : BaseFinder<Bet>, IBetFinder
    {
        public BetFinder(IDbSet<Bet> entity) : base(entity)
        {
        }

        public Task<List<Bet>> FindAllBets()
        {
            return Find().ToListAsync();
        }

        public Task<List<Bet>> FindBetByUser(Guid userId)
        {
            return Find().Where(x => x.User.Id == userId).ToListAsync();
        }

        public Task<List<Bet>> FindOpenBets()
        {
            return Find().Where(x => x.IsClosed == false).ToListAsync();
        }

        public Task<List<Bet>> FindBetByRace(Guid raceId)
        {
            return Find().Where(x => x.RaceId == raceId).ToListAsync();
        }
    }
}
