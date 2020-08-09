using ShopAction.Data.Enum;
using System;

namespace ShopAction.Data.Entities
{
    public class Transaction:BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public TransactionStatus Status { get; set; }
        public string Provider { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
