using Iot.Device.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iot.Device.Domain.Entities
{
    public class Device: BaseEntity
    {
        public string Name { get; set; }

        public ProtocolTypeLookup ProtocolType { get; set; } //TODO: ENUM MODBUS-SNMP 
        public int SlaveAddress { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string RequestTime { get; set; }

      
    }
}
