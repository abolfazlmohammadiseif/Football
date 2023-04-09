using Arch.EntityFrameworkCore.UnitOfWork;
using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Domain.Seedwork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        //IUnitOfWork UnitOfWork { get; }
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        T Add(T item);
        void Update(T item);
        void Delete(T item);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
    }
}
