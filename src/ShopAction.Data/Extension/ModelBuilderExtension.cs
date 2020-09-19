using Microsoft.EntityFrameworkCore;
using ShopAction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = Guid.NewGuid(),Name = "Tieng Viet", IsDefault = true },
                new Language() { Id = Guid.NewGuid(),Name = "English", IsDefault = false }
                ); ;
        }
    }
}
