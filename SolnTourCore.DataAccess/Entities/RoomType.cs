using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class RoomType
	{
		[Key, Column("room_type_id")]
		public int RoomTypeId { get; set; }
		[Column("room_type_name")]
		public string RoomTypeName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
}
room_type_id SERIAL UNIQUE NOT NULL PRIMARY KEY,
room_type_name VARCHAR(80) NOT NULL,
description VARCHAR(280) NOT NULL