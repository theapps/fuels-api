using api.Domain;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class AppDb: DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType{Id = 1, Name = "Benzina"},new FuelType{Id = 2, Name = "Diesel"},new FuelType{Id = 3, Name = "GPL"},new FuelType{Id = 4, Name = "Hybrid"}
            );
            
//            modelBuilder.Entity<VehicleType>().HasData(
//                new VehicleType{Id =1, Name = "Autoturism"},new VehicleType{Id =2, Name = "Transport marfa"},new VehicleType{Id =3, Name = "Transport persoane"}
//            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}