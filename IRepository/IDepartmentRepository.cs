using Task.Models;
using Task.ViewModels;

namespace Task.IRepository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);

        void Update(DepartmentVM departmentVM);
        void Create(DepartmentVM departmentVM);
        bool Delete(int id);
    }
}
