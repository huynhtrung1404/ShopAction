using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Languages");
        }
    }
}
