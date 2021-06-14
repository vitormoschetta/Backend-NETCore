using System.Linq;
using Domain.Entities;

namespace Infra.Context
{
    public class InitializeData
    {
        public static void InitializeProducts(AppDbContext context)
        {
            if (context.Product.Any())
                return;

            for (int i = 1; i < 13; i++)
            {
                var product = new Product($"Product {i}", (i + i) * 2);

                context.Product.Add(product);
            }

            context.SaveChanges();
        }
    }
}