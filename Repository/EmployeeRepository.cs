using Task.Data;
using Task.DTO;
using Task.IRepository;
using Task.Models;

namespace Task.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.Find(id);
        }

        public void Create(EmployeeDTO empDTO)
        {
            Employee employee = new Employee();
            employee.Name = empDTO.Name;
            employee.salary = empDTO.salary;
            employee.DepartmentId = empDTO.DepartmentId;

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Update(EmployeeDTO empDTO)
        {
            var employee = context.Employees.Find(empDTO.Id);
            if (employee != null)
            {
                employee.Name = empDTO.Name;
                employee.salary = empDTO.salary;
                employee.DepartmentId = empDTO.DepartmentId;
                context.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
