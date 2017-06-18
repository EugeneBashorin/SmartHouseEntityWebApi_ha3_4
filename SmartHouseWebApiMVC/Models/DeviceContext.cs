using SimpleSmartHouse1._0;
using System.Data.Entity;

namespace SmartHouseWebApiMVC.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(): base("DefaultConnection")
         {
            Database.SetInitializer<DeviceContext>(new DeviceContextInitializer());
        }
        public DbSet<Device> Devices { get; set; }
        //public DbSet<Heater> Heaters { get; set; }
        //public DbSet<Illuminator> Illuminators { get; set; }
        //public DbSet<AirCondition> ACs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Device>().ToTable(nameof(Devices));
        //    //    modelBuilder.Entity<Illuminator>().ToTable(nameof(Illuminators));
        //    //    modelBuilder.Entity<AirCondition>().ToTable(nameof(ACs));
        //    //    modelBuilder.Entity<Heater>().ToTable(nameof(Heaters));


        //    //    modelBuilder.Entity<Device>().HasKey(d => d.Id);
        //    //    modelBuilder.Entity<Device>().Property(d => d.Name).IsRequired().HasMaxLength(1000);
        //    //    modelBuilder.Entity<Device>().Property(d => d.State).IsRequired();
        //    //    // идём дальше...
        //    //    modelBuilder.Entity<Illuminator>().Property(i => i.Bright).IsRequired();
        //    //    // air conditions
        //    //    modelBuilder.Entity<AirCondition>().Property(a => a.Mode).IsRequired();
        //    //    modelBuilder.Entity<AirCondition>().Property(a => a.Temperature).IsRequired();
        //    //    // heater
        //    //    modelBuilder.Entity<Heater>().Property(h => h.Mode).IsRequired();
        //    //    modelBuilder.Entity<Heater>().Property(h => h.Temperature).IsRequired();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}