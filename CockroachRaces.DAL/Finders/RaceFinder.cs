using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;

namespace CockroachRaces.DAL.Finders
{
    public class RaceFinder : BaseFinder<Race>, IRaceFinder
    {
        public RaceFinder(IDbSet<Race> entity) : base(entity)
        {
        }

        public Task<List<Race>> FindAllRaces()
        {
            return Find().ToListAsync();
        }

        public Task<List<Race>> FindActiveRaces()
        {
            var now = DateTimeOffset.Now;
            return Find().Where(x => x.StartTime.Add(x.Duration) < now).ToListAsync();
        }
    }
}
