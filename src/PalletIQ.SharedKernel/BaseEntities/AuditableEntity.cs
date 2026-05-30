using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.BaseEntities
{
    public abstract class AuditableEntity : TenantEntity
    {
        protected AuditableEntity() { }

        protected AuditableEntity(Guid id, Guid tenantId, Guid createdBy) : base(id, tenantId)
        {
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid CreatedBy { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; protected set; }

        public Guid? UpdatedBy { get; protected set; }
    
        public void MarkUpdated(Guid updatedBy)
        {
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
