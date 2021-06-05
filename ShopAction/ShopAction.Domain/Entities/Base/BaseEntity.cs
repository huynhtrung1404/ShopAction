using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
