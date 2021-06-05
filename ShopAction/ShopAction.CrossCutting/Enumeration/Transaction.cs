using System;
namespace ShopAction.CrossCutting.Enumeration
{
    public enum Transaction
    {
        Success,
        Fail,
        Pending,
        Waiting,
        Cancel
    }
}
