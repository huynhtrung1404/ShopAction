using System;

namespace ShopAction.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public BaseEntity()
        {
            Id = new Guid();
        }
    }
}
