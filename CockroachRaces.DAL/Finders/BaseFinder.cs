using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;

namespace CockroachRaces.DAL.Finders
{
    public class BaseFinder<T> : IFinder<T> where T : class
    {
        private readonly IDbSet<T> _entity;

        public BaseFinder(IDbSet<T> entity)
        {
            _entity = entity;
        }

        public IQueryable<T> Find()
        {
            return _entity.AsQueryable();
        }
    }
}
