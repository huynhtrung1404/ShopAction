using ShopAction.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ShopAction.Domain.Entities
{
    public class Transaction : BaseEntity
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
    }
}
