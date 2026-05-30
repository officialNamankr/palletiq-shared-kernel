using System;
using System.Collections.Generic;
using System.Text;
using PalletIQ.SharedKernel.BaseEntities;

namespace PalletIQ.SharedKernel.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
