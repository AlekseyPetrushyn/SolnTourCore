using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class HotelCategory
	{
		[Key, Column("hotel_category_id")]
		public int HotelCategoryId { get; set; }
		[Column("hotel_category_name")]
		public string HotelCategoryName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
}
