using System;
using System.Collections.Generic;
using System.Text;
using PalletIQ.SharedKernel.Abstractions;

namespace PalletIQ.SharedKernel.Context
{
    public class TenantContext : ITenantContext
    {
        private Guid _tenantId;
        private string _tenantName = string.Empty;
        private string _plan = string.Empty;

        
        public Guid TenantId => _tenantId;

        public string TenantName => _tenantName;

        public string Plan => _plan;

        public bool IsResolved => _tenantId != Guid.Empty;


        public void SetTenant(Guid tenantId, string tenantName, string plan)
        {
            if (tenantId == Guid.Empty)
                throw new ArgumentException("Tenant ID cannot be empty.", nameof(tenantId));
            _tenantId = tenantId;
            _tenantName = tenantName;
            _plan = plan;
        }
    }
}
