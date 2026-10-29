using System;
using System.Collections.Generic;
using System.Text;
using Assignment10._3.Models;
using Microsoft.EntityFrameworkCore;


namespace Assignment10._3.Data
{
    public class CarContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<BillGatesGarage> Garages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=KILLUA;initial catalog=Assignment10.3;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillGatesGarage>().HasData(
                new BillGatesGarage { GarageID = 1, Location = "WA" },
                new BillGatesGarage { GarageID = 2, Location = "CA" },
                new BillGatesGarage { GarageID = 3, Location = "NY" },
                new BillGatesGarage { GarageID = 4, Location = "FL" },
                new BillGatesGarage { GarageID = 5, Location = "TX" }
                );


            modelBuilder.Entity<Car>().HasData(
                new Car { VIN = 11111111, GarageID = 1, Make = "Bugatti", Model = "Chiron", Year = 2022, Price = 3000000.0 },
                new Car { VIN = 22222222, GarageID = 1, Make = "Rolls-Royce", Model = "Phantom", Year = 2023, Price = 500000.0 },
                new Car { VIN = 33333333, GarageID = 2, Make = "Lamborghini", Model = "Aventador", Year = 2021, Price = 450000.0 },
                new Car { VIN = 44444444, GarageID = 2, Make = "Ferrari", Model = "F40", Year = 2023, Price = 2500000.0 },
                new Car { VIN = 55555555, GarageID = 3, Make = "Bentley", Model = "Continental GT", Year = 2024, Price = 250000.0 },
                new Car { VIN = 66666666, GarageID = 3, Make = "McLaren", Model = "P1", Year = 2022, Price = 1800000.0 },
                new Car { VIN = 77777777, GarageID = 4, Make = "Porsche", Model = "911GT3 ", Year = 2023, Price = 200000.0 },
                new Car { VIN = 88888888, GarageID = 5, Make = "Aston Martin", Model = "DBS", Year = 2022, Price = 330000.0 }
            );
        }

    }
}
