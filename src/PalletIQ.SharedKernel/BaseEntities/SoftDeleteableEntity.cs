using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.BaseEntities
{
    public abstract class SoftDeleteableEntity : AuditableEntity
    {
        public SoftDeleteableEntity() { }

        public SoftDeleteableEntity(Guid id, Guid tenantId, Guid createdBy) : base(id, tenantId, createdBy)
        {
        }

        public bool IsDeleted { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public Guid? DeletedBy { get; protected set; }

        public void MarkDeleted(Guid deletedBy)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedBy = null;
            DeletedAt = null;
        }
    }
}
