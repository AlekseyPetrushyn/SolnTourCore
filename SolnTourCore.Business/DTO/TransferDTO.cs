using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
    public class TransferDTO
    {
        public int TransferId { get; set; }
        public int TransportId { get; set; }
        public int DepartureCityId { get; set; }
        public int DestinationCityId { get; set; }
        public decimal Price { get; set; }

        public TransportDTO Transport { get; set; }
        public DepartureCityDTO DepartureCity { get; set; }
        public DestinationCityDTO DestinationCity { get; set; }
    }
}
