using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class TourOperator
	{
		[Key, Column("operator_id")]
		public int OperatorId { get; set; }
		[Column("operator_name")]
		public string OperatorName { get; set; }
		[ForeignKey("ServiceId")]
		public AdditionalService AdditionalService { get; set; }
		[Column("additional_service_id")]
		public int ServiceId { get; set; }
		[ForeignKey("TransferId")]
		public Transfer Transfer { get; set; }
		[Column("transfer_id")]
		public int TransferId { get; set; }

		public IEnumerable<Tour> Tours { get; set; }
	}
}
