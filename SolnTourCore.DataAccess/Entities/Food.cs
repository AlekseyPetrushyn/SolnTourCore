using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Food
	{
		[Key, Column("food_id")]
		public int FoodId { get; set; }
		[Column("food_name")]
		public string FoodName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
}