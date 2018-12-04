using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockroachRaces.BLL.CommonInterfaces
{
    public interface IFinder<out T> where T : class
    {
        IQueryable<T> Find();
    }
}
