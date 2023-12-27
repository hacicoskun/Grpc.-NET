using Iot.Device.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iot.Device.Persistence
{
    public interface IDeviceDbContext
    {
        DbSet<Domain.Entities.Device> Devices { get; set; } 
        Task<int> SaveChangesAsync();
    }
}
