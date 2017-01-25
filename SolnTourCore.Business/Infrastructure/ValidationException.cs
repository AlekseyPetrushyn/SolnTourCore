using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.Infrastructure
{
	public class ValidationException : Exception
	{
			//валидация данных на бизнес уровне
			//валидация с передачей информации на уровень представления
		public string Property { get; protected set; }
		public ValidationException(string message, string property) : base(message)
		{
			Property = property;
		}
	}
}
