using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task.Data;
using Task.IRepository;
using Task.Models;
using Task.ViewModels;

namespace Task.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ApplicationDbContext context;
        private readonly object ModelState;

        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        }

        public void Create(DepartmentVM departmentVM)
        {
                Department department = new Department();
                department.Id = departmentVM.Id;
                department.Name = departmentVM.Name;

                context.Departments.Add(department);
                context.SaveChanges();
        }

        public void Update(DepartmentVM departmentVM)
        {
            var department = context.Departments.Find(departmentVM.Id);
            if (department != null)
            {
                department.Name = departmentVM.Name;
                context.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var dept = context.Departments.Find(id);
            if(dept != null)
            {
                context.Departments.Remove(dept);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
