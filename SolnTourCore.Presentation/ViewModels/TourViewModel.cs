using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class TourViewModel
    {
        public int TourId { get; set; }
        public int TourOperatorId { get; set; }
        public int HotelId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DestinationDate { get; set; }

        public TourOperatorViewModel TourOperator { get; set; }
        public HotelViewModel Hotel { get; set; }
    }
}
