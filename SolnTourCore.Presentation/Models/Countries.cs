using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SolnTourCore.Presentation.Models
{
	public class country
	{
		[Key]
		public int country_id { get; set; }
		public string country_name { get; set; }
		
	}

	public class CountryContext : DbContext
	{
		public CountryContext(DbContextOptions<CountryContext> options) : base(options)
		{
			
		}
		public DbSet<country> countries { get; set; }
	}
}
