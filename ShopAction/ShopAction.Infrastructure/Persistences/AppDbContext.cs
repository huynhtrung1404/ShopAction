using System;
using Microsoft.EntityFrameworkCore;

namespace ShopAction.Infrastructure.Persistences
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
    }
}
