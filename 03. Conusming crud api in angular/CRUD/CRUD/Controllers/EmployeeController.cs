using CRUD.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EmployeeController(ApplicationDbContext context) 
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult getAllEmployees()
        {
            var employees = context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult getSingleEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee is null) return NotFound("Employee not found");
            
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult addEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var employee = new Employee
            {
                Name = createEmployeeDto.Name,
                Designation = createEmployeeDto.Designation,
            };

            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public ActionResult updateEmployee(int id, CreateEmployeeDto dto)
        {
            var employee = context.Employees.Find(id);
            if (employee is null) return NotFound("Employee not found.");

            employee.Name= dto.Name;
            employee.Designation= dto.Designation;

            context.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee is null) return NotFound("Employee not found.");

            context.Remove(employee);
            context.SaveChanges();
            return Ok("Employee has been deleted.");
        }
    }
}
