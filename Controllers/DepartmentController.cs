using Microsoft.AspNetCore.Mvc;
using Task.IRepository;
using Task.DTO;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = departmentRepository.GetAll();
            if (departments != null)
            {
                return Ok(departments);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var departments = departmentRepository.GetById(id);
            if (departments != null)
            {
                return Ok(departments);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(DepartmentDTO deptVM)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Create(deptVM);
                return Created($"https://localhost:7235/api/Department/{deptVM.Id}", deptVM);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(DepartmentDTO deptVM)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Update(deptVM);
                return Ok(deptVM);
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (departmentRepository.Delete(id))
            {
                return Ok();
            }
            else { return BadRequest(); }
        }

    }
}
