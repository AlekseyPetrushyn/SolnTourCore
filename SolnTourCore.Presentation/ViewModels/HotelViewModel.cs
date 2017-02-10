using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class HotelViewModel
    {
        public int HotelId { get; set; }
        public int PlaceId { get; set; }
        public string HotelName { get; set; }
        public int HotelCategoryId { get; set; }
        public int FoodId { get; set; }
        public int RoomTypeId { get; set; }
        public int AccomodationId { get; set; }
        public int LocationId { get; set; }
        public int RecreationId { get; set; }
        public decimal Price { get; set; }

        public PlaceViewModel Place { get; set; }
        public HotelCategoryViewModel HotelCategory { get; set; }
        public FoodViewModel Food { get; set; }
        public RoomTypeViewModel RoomType { get; set; }
        public AccomodationViewModel Accomodation { get; set; }
        public LocationViewModel Location { get; set; }
        public RecreationViewModel Recreation { get; set; }
    }
}
