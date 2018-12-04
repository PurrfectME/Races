using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.DAL.EntitiesContext;

namespace CockroachRaces.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }


        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine(@"Object: " + validationError.Entry.Entity.ToString());
                    Console.WriteLine("");
                    foreach (var err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(@err.ErrorMessage);
                    }
                }
            }
        }
    }
}
