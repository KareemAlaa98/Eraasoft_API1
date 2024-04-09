using Task.Models;
using Task.DTO;

namespace Task.IRepository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);

        void Update(DepartmentDTO departmentDTO);
        void Create(DepartmentDTO departmentDTO);
        bool Delete(int id);
    }
}
