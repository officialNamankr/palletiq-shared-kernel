using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
