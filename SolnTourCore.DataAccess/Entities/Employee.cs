using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Employee
	{
		[Key, Column("employee_id")]
		public int EmployeeId { get; set; }
		[Column("second_name")]
		public string SecondName { get; set; }
		[Column("first_name")]
		public string FirstName { get; set; }
		[Column("patronymic")]
		public string Patronymic { get; set; }
		[Column("birth_day")]
		public DateTime BirthDay { get; set; }
		[Column("adress")]
		public string Address { get; set; }
		[Column("mobil_number")]
		public string MobilNumber { get; set; }
		[Column("work_number")]
		public string WorkNumber { get; set; }
		[ForeignKey("AccessId")]
		public AccessLevel AccessLevel { get; set; }
		[Column("access_id")]
		public int AccessId { get; set; }
		[Column("login")]
		public string Login { get; set; }
		[Column("password")]
		public string Password { get; set; }
	}
}
