using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task.Data;
using Task.IRepository;
using Task.Models;
using Task.DTO;

namespace Task.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ApplicationDbContext context;

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

        public void Create(DepartmentDTO departmentDTO)
        {
                Department department = new Department();
                department.Id = departmentDTO.Id;
                department.Name = departmentDTO.Name;

                context.Departments.Add(department);
                context.SaveChanges();
        }

        public void Update(DepartmentDTO departmentDTO)
        {
            var department = context.Departments.Find(departmentDTO.Id);
            if (department != null)
            {
                department.Name = departmentDTO.Name;
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
