using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;

namespace CockroachRaces.DAL.Finders
{
    public class CockroachFinder : BaseFinder<Cockroach>, ICockroachFinder
    {
        public CockroachFinder(IDbSet<Cockroach> entity) : base(entity)
        {
        }

        public Task<List<Cockroach>> FindAllCockroaches()
        {
            return Find().ToListAsync();
        }
    }
}
