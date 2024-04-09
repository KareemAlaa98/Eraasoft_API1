using Task.DTO;
using Task.Models;

namespace Task.IRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void Create(EmployeeDTO empDTO);
        void Update(EmployeeDTO empDTO);
        bool Delete(int id);
    }
}
