using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Abstractions
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        Guid TenantId { get; }

        string Email { get; }

        string FullName { get; }

        IReadOnlyList<string> Roles { get; }

        string Plan { get; }

        bool IsAuthenticated { get; }

        bool IsInRoles(string role);

        bool IsInAnyRole(params string[] roles);
    }
}
