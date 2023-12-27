using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iot.Device.Persistence
{
    public class DeviceDbContext :DbContext, IDeviceDbContext
    {
        public DeviceDbContext()
        {

        }
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Domain.Entities.Device> Devices { get ; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
