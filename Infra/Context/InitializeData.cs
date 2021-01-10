using System;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Context
{
    public class InitializeData
    {
        public static void InitializeProducts(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Product.Any())  // <-- Se já possui dados, não prossegue
                    return;

                for (int i = 1; i < 13; i++)
                {
                    var product = new Product(i.ToString(), $"Product {i}", (i + i) * 2);

                    context.Product.Add(product);
                    context.SaveChanges();
                }

            }
        }
    }
}