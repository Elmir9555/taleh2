using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackendLahiye.Entities;

namespace BackendLahiye.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> exp);
        Task<T> FindAsync(int id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> exp);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable GetQueryable();
        Task<List<T>> GetAllOrderByAsync(Expression<Func<T, int>> exp, bool AscORDesc);
    }
}
