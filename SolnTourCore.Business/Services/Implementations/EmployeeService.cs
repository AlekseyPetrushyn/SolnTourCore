using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _repository { get; set; }

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(_repository.GetAll());
        }

        public EmployeeDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Employee, EmployeeDTO>(_repository.Get(id));
        }

        public void Create(EmployeeDTO item)
        {
            Employee employee = new Employee
            {
                EmployeeId = _repository.GetAll().Count() + 1,
                SecondName = item.SecondName,
                FirstName = item.FirstName,
                Patronymic = item.Patronymic,
                BirthDay = item.BirthDay,
                Address = item.Address,
                MobilNumber = item.MobilNumber,
                WorkNumber = item.WorkNumber,
                AccessId = item.AccessId,
                Login = item.Login,
                Password = item.Password
            };
            _repository.Create(employee);
        }

        public void Update(EmployeeDTO item)
        {
            var employee = _repository.Get(item.EmployeeId);
            employee.SecondName = item.SecondName;
            employee.FirstName = item.FirstName;
            employee.Patronymic = item.Patronymic;
            employee.BirthDay = item.BirthDay;
            employee.Address = item.Address;
            employee.MobilNumber = item.MobilNumber;
            employee.WorkNumber = item.WorkNumber;
            employee.AccessId = item.AccessId;
            employee.Login = item.Login;
            employee.Password = item.Password;
            _repository.Update(employee);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
