using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PalletIQ.SharedKernel.Results;

namespace PalletIQ.SharedKernel.CQRS
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
