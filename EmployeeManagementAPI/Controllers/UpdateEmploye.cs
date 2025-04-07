using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Controllers
{
    public class UpdateEmploye
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

        [Required(ErrorMessage = "Por favor indique el salario del empleado.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un número positivo.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Por favor indique la fecha de contratación.")]
        public DateTime HiringDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}