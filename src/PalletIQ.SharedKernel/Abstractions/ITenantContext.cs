using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Abstractions
{
    public interface ITenantContext
    {
        Guid TenantId { get; }

        string TenantName { get; }

        string Plan { get; }
        /// <summary>
        /// True when TenantId has been resolved form JWT
        /// </summary>
        bool IsResolved { get; }
    }
}
