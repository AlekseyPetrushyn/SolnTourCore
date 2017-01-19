using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class AccessLevel
	{
		[Key, Column("access_id")]
		public int AccessId { get; set; }
		[Column("access_name")]
		public string AccessName { get; set; }
		[Column("description")]
		public string Description { get; set; }

		public IEnumerable<Employee> Employees { get; set; }
	}
}