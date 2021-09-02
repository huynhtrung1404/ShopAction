using System;
namespace ShopAction.CrossCutting.Constants
{
    public static class AppConstant
    {
        public const string ConnectionString = "DefaultConnection";
        public const string TokenKey = "Tokens:Key";
        public const string Issuer = "Tokens:Issuer";
        public const string Audience = "Tokens:Audience";
    }

    public static class Schemas
    {
        public const string Product = "Product";
        public const string Identity = "Identity";
    }
}