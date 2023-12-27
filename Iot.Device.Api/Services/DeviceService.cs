using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Iot.Device.Api.Services
{
    public class DeviceService : Device.DeviceBase
    {
        public override Task<DeviceDto> CreateDevice(DeviceRequest request, ServerCallContext context)
        {
            var createdDevice = new DeviceDto
            {
                DeviceId = "123",
                Name = request.Name
            };
            return Task.FromResult(createdDevice);
        }

        public override Task<DeviceDto> GetDevice(DeviceIdRequest request, ServerCallContext context)
        {
            var device = new DeviceDto
            {
                DeviceId = request.DeviceId,
                Name = "DeviceName"
            };
            return Task.FromResult(device);
        }

        public override async Task ListDevices(Empty request, IServerStreamWriter<DevicesDto> responseStream, ServerCallContext context)
        {
            var devices = GetListOfDevices();

            var devicesDto = new DevicesDto();
            devicesDto.Devices.AddRange(devices);

            await responseStream.WriteAsync(devicesDto);
        }

        private List<DeviceDto> GetListOfDevices()
        {
          
            return new List<DeviceDto>
            {
                new DeviceDto { DeviceId = "1", Name = "Device1" },
                new DeviceDto { DeviceId = "2", Name = "Device2" } 
            };
        }
    }
}
