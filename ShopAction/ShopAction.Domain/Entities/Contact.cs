using ShopAction.Domain.Entities.Base;
using ShopAction.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
        public Contact()
        {
            Id = Guid.NewGuid();
        }
    }
}
