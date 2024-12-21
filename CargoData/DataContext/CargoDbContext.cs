using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargoEntity;
using System.Runtime;

namespace CargoData.DataContext
{
    /// <summary>
    /// Represents the Database Context for the Cargo Manager System.
    /// The context is responsible for interacting with the underlying database and managing the entities within the system.
    /// </summary>
    public class CargoDbContext : DbContext
    {
        /// <summary>
        /// Constructor to initialize the DbContext with provided options.
        /// </summary>
        /// <param name="options">DbContext options provided during instantiation.</param>
        public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// DbSet for storing Admin entities in the database.
        /// </summary>
        public DbSet<Admin>? Admins { get; set; }

        /// <summary>
        /// DbSet for storing Employee entities in the database.
        /// </summary>
        public DbSet<Employee>? Employees { get; set; }

        /// <summary>
        /// DbSet for storing Customer entities in the database.
        /// </summary>
        public DbSet<Customer>? Customers { get; set; }

        /// <summary>
        /// DbSet for storing CargoType entities in the database.
        /// </summary>
        public DbSet<CargoType>? CargoTypes { get; set; }

        /// <summary>
        /// DbSet for storing CargoFare entities in the database.
        /// </summary>
        public DbSet<CargoFare>? CargoFare { get; set; }

        /// <summary>
        /// DbSet for storing Product entities in the database.
        /// </summary>
        public DbSet<Product>? Products { get; set; }

        /// <summary>
        /// DbSet for storing CargoOrder entities in the database.
        /// </summary>
        public DbSet<CargoOrder>? CargoOrders { get; set; }

        /// <summary>
        /// DbSet for storing CargoBooking entities in the database.
        /// </summary>
        public DbSet<CargoBooking>? CargoBooking { get; set; }

        /// <summary>
        /// DbSet for storing WareHouse entities in the database.
        /// </summary>
        public DbSet<WareHouse>? WareHouse { get; set; }

        /// <summary>
        /// DbSet for storing GatePass entities in the database.
        /// </summary>
        public DbSet<GatePass>? GatePasses { get; set; }

        /// <summary>
        /// Overrides the default behavior of model creation for the Cargo Manager System.
        /// Configures the entity models, relationships, and keys using the Entity Framework Core.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Define composite primary key for GatePass entity
            //modelBuilder.Entity<GatePass>()
            //    .HasKey(gp => new { gp.GatePassId, gp.GatePassNumber /* ... other properties if any ... */ });

            //// ... other configurations ...
            //modelBuilder.Entity<TruckExit>()
            //   .HasOne(te => te.GatePass)
            //   .WithMany()  // Assuming one-to-many relationship
            //   .HasForeignKey(te => te.GatePass)

            // modelBuilder.Entity<GatePass>()
            //.HasIndex(e => e.GatePassNumber)
            //.IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// DbSet for storing TruckExit entities in the database.
        /// </summary>
        public DbSet<TruckExit>? TruckExit { get; set; }

        

        /// <summary>
        /// DbSet for storing HousekeepingMovement entities in the database.
        /// </summary>
        public DbSet<HousekeepingMovement>? HousekeepingMovement { get; set; }

    }

}
