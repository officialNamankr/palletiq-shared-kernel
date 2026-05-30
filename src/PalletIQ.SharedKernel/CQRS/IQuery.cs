using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PalletIQ.SharedKernel.Results;

namespace PalletIQ.SharedKernel.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
