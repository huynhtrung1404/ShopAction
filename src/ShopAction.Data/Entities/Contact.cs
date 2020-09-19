using ShopAction.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Entities
{
    public class Contact: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
    }
}
