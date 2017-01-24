using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class TourOperatorDTO
	{
		public int OperatorId { get; set; }
		public string OperatorName { get; set; }
		public AdditionalServiceDTO AdditionalService { get; set; }
		public int AdditionalServiceId { get; set; }
		public TransferDTO Transfer { get; set; }
		public int TransferId { get; set; }
	}
}
