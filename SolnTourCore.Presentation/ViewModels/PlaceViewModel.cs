using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class PlaceViewModel
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public CountryViewModel Country { get; set; }
        public int CountryId { get; set; }
    }
}
