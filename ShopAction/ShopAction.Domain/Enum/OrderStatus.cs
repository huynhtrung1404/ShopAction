using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Domain.Enum
{
    public enum OrderStatus
    {
        InProgress,
        Confirmed,
        Shipping,
        Success,
        Canceled
    }
}
