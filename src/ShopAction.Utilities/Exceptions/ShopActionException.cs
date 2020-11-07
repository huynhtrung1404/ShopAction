

using System;

namespace ShopAction.Utilities.Exceptions
{
    public class ShopActionException :Exception
    {
        public ShopActionException()
        {

        }
        public ShopActionException(string message):base(message)
        {

        }
        public ShopActionException(string message, Exception inner) : base(message, inner) { }
    }
}
