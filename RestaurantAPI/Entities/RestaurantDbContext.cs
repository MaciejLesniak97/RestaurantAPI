using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString =
            "Server=DESKTOP-BVM4380\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        /// <summary>
        /// Method responsible for restricting some columns of tables in db
        /// when db is being created
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // column 'Name' of table Restaurant in db has to be required and max length is 25 characters
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            //column 'Name' of table Dish is required
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

        }

        /// <summary>
        /// Configuring connection to database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
