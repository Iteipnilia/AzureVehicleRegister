using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegister.DTO.Request
{
    public class VehicleServiceDto
    {
        public int VehicleServiceId { get; set; }
        public VehicleDto Vehicle { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceType { get; set; }
        public bool IsServiceCompleted { get; set; }
    }

    public class GetAllVehicleServicesResponseDto
    {
        public IList<VehicleServiceDto> VehicleServices { get; set; } = new List<VehicleServiceDto>();
    }
}
