using System;
using Microsoft.EntityFrameworkCore;

namespace ParkingApp.Model
{
    public class ParkingContext: DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Model = "Chevrolet Aveo"
                },
                new Car
                {
                    Id = 2,
                    Model = "Opel Corsa"
                },
                new Car
                {
                    Id = 3,
                    Model = "Renault Clio"
                }
            );
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    LicensePlate = "lalalalal"
                },
                new Driver
                {
                    Id = 2,
                    LicensePlate = "nanananna"
                },
                new Driver
                {
                    Id = 3,
                    LicensePlate = "blblblbl"
                }
            );
        }
    }
}