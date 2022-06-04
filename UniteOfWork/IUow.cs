using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Entities;
using BackendLahiye.Repository;

namespace BackendLahiye.UniteOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangeAsync();

    }
}
