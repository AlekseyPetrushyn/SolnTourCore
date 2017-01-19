using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Transport
	{
		[Key, Column("transport_id")]
		public int TransportId { get; set; }
		[Column("transport_name")]
		public string TransportName { get; set; }

	}
}
