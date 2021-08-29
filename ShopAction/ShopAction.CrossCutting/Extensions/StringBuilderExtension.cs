using System;
namespace ShopAction.CrossCutting.Extensions
{
    public static class StringBuilderExtension
    {
        public static string ToStringExtension(this object input)
        {
            return Convert.ToString(input);
        }
    }
}
