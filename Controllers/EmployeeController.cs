using Microsoft.AspNetCore.Mvc;
using Task.DTO;
using Task.IRepository;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = employeeRepository.GetAll();
            if (employees != null)
            {
                // mapping
                List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
                foreach (var item in employees)
                {
                    EmployeeDTO empDto = new EmployeeDTO();
                    empDto.Id = item.Id;
                    empDto.Name = item.Name;
                    empDto.salary = item.salary;
                    empDto.DepartmentId = item.DepartmentId;

                    employeeDTOs.Add(empDto);
                }
                return Ok(employeeDTOs);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = employeeRepository.GetById(id);

            if (employee != null)
            {
                EmployeeDTO empDto = new EmployeeDTO();
                empDto.Id = employee.Id;
                empDto.Name = employee.Name;
                empDto.salary = employee.salary;
                empDto.DepartmentId = employee.DepartmentId;
                return Ok(empDto);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Create(empDTO);
                return Created($"https://localhost:7235/api/Department/{empDTO.Id}", empDTO);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(empDTO);
                return Ok(empDTO);
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (employeeRepository.Delete(id))
            {
                return Ok();
            }
            else { return BadRequest(); }
        }

    }
}
