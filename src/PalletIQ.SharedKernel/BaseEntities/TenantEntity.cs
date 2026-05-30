using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.BaseEntities
{
    public abstract class TenantEntity : Entity
    {
        protected TenantEntity() { }

        protected TenantEntity(Guid id, Guid tenantId) : base(id)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }
    }
}
