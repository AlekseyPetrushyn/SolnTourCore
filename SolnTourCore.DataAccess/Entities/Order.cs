using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Order
	{
		[Key, Column("order_id")]
		public int OrderId { get; set; }
		[ForeignKey("TourId")]
		public Tour Tour { get; set; }
		[Column("tour_id")]
		public int TourId { get; set; }
		[ForeignKey("ClientId")]
		public Client Client { get; set; }
		[Column("client_id")]
		public int ClientId { get; set; }
		[ForeignKey("EmployeeId")]
		public Employee Employee { get; set; }
		[Column("employee_id")]
		public int EmployeeId { get; set; }
	}
}