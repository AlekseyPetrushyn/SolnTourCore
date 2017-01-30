using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class TransferViewModel
    {
        public int TransferId { get; set; }
        public int TransportId { get; set; }
        public int DepartureCityId { get; set; }
        public int DestinationCityId { get; set; }
        public decimal Price { get; set; }
    }
}
