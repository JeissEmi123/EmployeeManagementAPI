using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Controllers
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Por favor ingrese el nombre del empleado.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor indique el cargo del empleado.")]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor indique el departamento del empleado.")]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor indique el salario.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un número positivo.")]
        public decimal Salary { get; set; }

        public DateTime? HiringDate { get; set; } 
    }
}