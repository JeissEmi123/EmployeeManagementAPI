using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesDbContext _context;

        public EmployeesController(EmployeesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

            var employees = await _context.Employees.ToListAsync();

            if (employees == null || !employees.Any())
                return NoContent();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "Empleado no encontrado." });
            }

            return Ok(employee);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (input.HiringDate.HasValue && input.HiringDate.Value > DateTime.UtcNow)
                return BadRequest(new { message = "La fecha de contratación no puede ser mayor a la actual" });

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = input.Name.Trim(),
                Position = input.Position.Trim(),
                Department = input.Department.Trim(),
                Salary = input.Salary,
                HiringDate = input.HiringDate ?? DateTime.UtcNow, 
                IsActive = true
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmploye input)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

        
            var employee = await _context.Employees.FindAsync(id);

        
            if (employee == null)
                return NotFound(new { message = "No se encontró ningún empleado con el ID proporcionado." });

        
        
            if (input.HiringDate > DateTime.UtcNow)
                return BadRequest(new { message = "La fecha de contratación no puede ser mayor a al actual." });

        
            employee.Name = input.Name.Trim();
            employee.Position = input.Position.Trim();
            employee.Department = input.Department.Trim();
            employee.Salary = input.Salary;
            employee.HiringDate = input.HiringDate;
            employee.IsActive = input.IsActive;

        
            await _context.SaveChangesAsync();

        
            return Ok(new
            {
                message = "La información del empleado fue actualizada exitosamente.",
                employee = new
                {
                    employee.Id,
                    employee.Name,
                    employee.Position,
                    employee.Department,
                    employee.Salary,
                    employee.HiringDate,
                    employee.IsActive
                }
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null || !employee.IsActive)
                return NotFound(new { message = "Empleado no encontrado o ya inactivo." });

            employee.IsActive = false;

          
            await _context.SaveChangesAsync();

            return Ok(new { message = "Empleado desactivado exitosamente." });
        }

    }
}
