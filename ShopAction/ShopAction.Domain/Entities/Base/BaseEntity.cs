using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
