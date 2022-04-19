using Microsoft.EntityFrameworkCore;
using ProducAPI.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducAPI.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Butter Chicken",
                Category = "Main",
                ImageFile = "",
                Description = "Aromatic golden chicken pieces in an incredible curry sauce.",
                Price = 18,
                SpicyLevel = "Mild"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {

                ProductId = 2,
                Name = "Vindaloo",
                Category = "Main",
                ImageFile = "",
                Description = "A standard element of Goan cuisine derived from the Portuguese carne de vinha d'alhos (meat in garlic marinade).",
                Price = 16,
                SpicyLevel = "High"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Lamb Roghanjosh",
                Category = "Curry",
                ImageFile = "",
                Description = "An indian lamb curry with a heady combination of intense spices in a creamy tomato curry sauce.",
                Price = 18,
                SpicyLevel = "Medium"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Paneer Butter Masala",
                Category = "Main",
                ImageFile = "",
                Description = "A rich & creamy curry made with paneer, spices, onions, tomatoes, cashews and butter.",
                Price = 18,
                SpicyLevel = "Mild"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Chicken Madras",
                Category = "Dessert",
                ImageFile = "",
                Description = "A madras curry is a fairly hot curry with a dark red thick sauce (the colour comes from the chillies and paprika).",
                Price = 18,
                SpicyLevel = "Mild"
            }); 

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Nepalese Momo",
                Category = "Starter",
                ImageFile = "",
                Description = "A dumpling made of all-purpose flour and filled with either meat or vegetables.",
                Price = 10,
                SpicyLevel = "Medium"
            });
        }
    }
}
