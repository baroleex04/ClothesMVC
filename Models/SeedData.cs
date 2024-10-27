using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClothesMVC.Data;
using System;
using System.Linq;

namespace ClothesMVC.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ClothesMVCContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ClothesMVCContext>>()))
        {
            // Look for any movies.
            if (context.Clothes.Any())
            {
                return;   // DB has been seeded
            }
            context.Clothes.AddRange(
                new Clothes
                {
                    Type = "Shoes",
                    Name = "Mizuno 123",
                    Size = "44",
                    Brand = "Mizuno",
                    DateBuy = DateTime.Now,
                    Price = 1500000
                },
                new Clothes
                {
                    Type = "Shirt",
                    Name = "New 123",
                    Size = "XXL",
                    Brand = "Uniqlo",
                    DateBuy = DateTime.Parse("2023-12-12"),
                    Price = 2000000
                },
                new Clothes
                {
                    Type = "Shorts",
                    Name = "The Best",
                    Size = "XL",
                    Brand = "GrimmDC",
                    DateBuy = DateTime.Now,
                    Price = 400000
                },
                new Clothes
                {
                    Type = "Socks",
                    Name = "New brand",
                    Size = "44",
                    Brand = "Yonex",
                    DateBuy = DateTime.Now,
                    Price = 10000
                }
            );
            context.SaveChanges();
        }
    }
}