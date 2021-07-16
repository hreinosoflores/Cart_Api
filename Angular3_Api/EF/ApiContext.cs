using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Angular3_Api.Models;

namespace Angular3_Api.EF
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<DetailOrder> DetailsOrder { get; set; }



        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Store>().HasData(new Store[] {

                new Store{
                  Id= 1,
                  Name= "Park Row at Beekman St",
                  Address= "38 Park Row",
                  City= "New York",
                  OpeningHours= "10:00 - 14:00 and 17:00 - 20:30"
                },
                new Store{
                  Id= 2,
                  Name= "Store Alcalá",
                  Address= "Calle de Alcalá, 21",
                  City= "Madrid",
                  OpeningHours= "10:00 - 14:00 and 17:00 - 20:30"
                },
                new Store{
                  Id= 3,
                  Name= "Chambers and West Broadway",
                  Address= "125 Chambers Street",
                  City= "New York",
                  OpeningHours= "10:00 - 14:00 and 17:00 - 20:30"
                },
                new Store{
                  Id= 4,
                  Name= "Covent Garden - Russell St",
                  Address= "10 Russell Street",
                  City= "London",
                  OpeningHours= "10:00 - 14:00 and 17:00 - 20:30"
                },
                new Store{
                  Id= 5,
                  Name= "Monmouth St",
                  Address= "11 Monmouth Street",
                  City= "London",
                  OpeningHours= "10:00 - 14:00 and 17:00 - 20:30"
                }
            });



            model.Entity<Product>().HasData(new Product[] {
                new Product{
                    Id= 1,
                    Name= "Essential TypeScript 4: From Beginner to Pro",
                    Price= 45,
                    Description= "Learn the essentials and more of TypeScript, a popular superset of the JavaScript language that adds support for static typing. TypeScript combines the typing features of C# or Java.",
                    Stock= 0
                },
                new Product{
                    Id= 2,
                    Name= "Hackeando el cerebro de tus compradores: PsychoGrowth",
                    Price= 5,
                    Description= "En Hackeando del cerebro de tus compradores, Corti nos revela cómo muchas compañías crean productos digitales o procesos de venta capaces de conectar con la psicología del comprador.",
                    Stock= 10
                },
                new Product{
                    Id= 3,
                    Name= "Angular Routing: Learn To Create client-side and SPA with Routing and Navigation",
                    Price= 17,
                    Description= "In this book, the reader will be able to focus on one concept of Angular in deep.",
                    Stock= 10
                },
                new Product{
                    Id= 4,
                    Name= "SanDisk 128GB Ultra MicroSDXC UHS-I Memory Card with Adapter",
                    Price= 19,
                    Description= "Ideal for Android smartphones and tablets, and MIL cameras. SanDisk Memory Zone app for easy file management (Download and Installation Required).",
                    Stock= 10
                },
                new Product{
                    Id= 5,
                    Name= "GoPro HERO9 Black - Waterproof Action Camera with Front LCD",
                    Price= 399,
                    Description= "5K Video - Shoot stunning video with up to 5K resolution, perfect for maintaining detail even when zooming in",
                    Stock= 10
                },
                new Product{
                    Id= 6,
                    Name= "CL3 Rated High-Speed 4K HDMI Cable - 6 Feet",
                    Price= 7,
                    Description= "HDMI A Male to A Male Cable: Supports Ethernet, 3D, 4K video and Audio Return Channel (ARC)",
                    Stock= 10
                },
                new Product{
                    Id= 7,
                    Name= "Logitech MK270 Wireless Keyboard and Mouse Combo",
                    Price= 32,
                    Description= "The USB receiver is conveniently located in the box, top flap. This wireless keyboard and mouse feature Logitech Advanced 2.4GHz technology with a range of up to 10 metres.",
                    Stock= 10
                },
                new Product{
                    Id= 8,
                    Name= "External CD Drive USB 3.0 Portable CD DVD +/-RW Drive DVD/CD ROM",
                    Price= 20,
                    Description= "Plug & play. Easy to use,powered by USB port. No external driver and Power needed. Just plug it into your USB port and the DVD driver will be detected",
                    Stock= 10
                }
            });

            model.Entity<Order>().HasData(new Order[] {
                new Order{
                    Id = 1,
                    Name = "Dominicode",
                    Date = "01/12/1995",
                    Pickup = false,
                    ShippingAddress = "Av. de la Granvia de Hospitalet, 115",
                    City = "Barcelona",
                    Total = 20.40M
                },
                new Order{
                    Id = 2,
                    Name = "Dominicode",
                    Date = "01/12/1995",
                    Pickup = true,
                    StoreId = 1,
                    Total = 105.30M
                }
            });

            model.Entity<DetailOrder>().HasData(new DetailOrder
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 10,
                Subtotal = 100M
               
            });


        }


    }
}
