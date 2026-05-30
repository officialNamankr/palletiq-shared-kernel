using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PalletIQ.SharedKernel.Results;

namespace PalletIQ.SharedKernel.CQRS
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
