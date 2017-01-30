using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.Services.Interfaces
{
	public interface IService<T> where T : class 
	{
		IEnumerable<T> GetAll();
		T Get(int id);
		void Create(T item);
		void Update(T item);
		void Delete(int id);
	}
}
