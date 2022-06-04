using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Context;
using BackendLahiye.Entities;
using BackendLahiye.Repository;

namespace BackendLahiye.UniteOfWork
{
    public class Uow : IUow
    {
        private readonly AppDbContext _context;

        public Uow(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
