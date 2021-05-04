using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.DTO.Request
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string VehicleType { get; set; }
        public double Weight { get; set; }
        public bool IsRegistered { get; set; }
        public double YearlyFee { get; set; }
        public IVehicleService BookedService { get; set; }
        public DateTime FirstUseInTraffic { get; set; }
    }
    public class GetAllVehiclesResponseDto
    {
        public IList<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
    }
}
