using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.Data
{
    public class AllContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<FurnitureName> FurnitureNames { get; set; }
        public DbSet<FurnitureType> FurnitureTypes { get; set; }
        public DbSet<Finishing> Finishings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        public AllContext(DbContextOptions<AllContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand[]
                {
                    new Brand {Id=1, Name="Fratelli Barri"}
                }
                );

            modelBuilder.Entity<Collection>().HasData(
                new Collection[]
                {
                    new Collection{Id=1, Name="Florence", BrandId=1}
                }
                );
            modelBuilder.Entity<FurnitureName>().HasData(
                new FurnitureName[]
                {
                    new FurnitureName{Id=1, Name="Side Table", CollectionId=1}
                }
                );
            modelBuilder.Entity<FurnitureType>().HasData(
                new FurnitureType[]
                {
                    new FurnitureType{Id=1, Name="Стол"}
                }
                );
            modelBuilder.Entity<Finishing>().HasData(
                new Finishing[]
                {
                    new Finishing{Id=1, Name="Silver "}
                }
                );
        }
    }
}
