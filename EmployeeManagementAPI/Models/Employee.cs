using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models;

/// <summary>
/// Representa a un empleado dentro del sistema.
/// Incluye información personal, laboral y estado dentro de la empresa.
/// </summary>
public class Employee
{
    /// <summary>
    /// Identificador único del empleado (se genera automáticamente al crear el registro).
    /// </summary>
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Nombre completo del empleado.
    /// </summary>
    [Required(ErrorMessage = "Por favor ingrese el nombre del empleado.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Cargo o posición que ocupa el empleado dentro de la empresa.
    /// </summary>
    [Required(ErrorMessage = "Por favor indique el cargo del empleado.")]
    [StringLength(100, ErrorMessage = "El cargo no puede exceder los 100 caracteres.")]
    public string Position { get; set; } = string.Empty;

    /// <summary>
    /// Departamento al que pertenece el empleado.
    /// </summary>
    [Required(ErrorMessage = "Por favor indique el departamento del empleado.")]
    [StringLength(100, ErrorMessage = "El nombre del departamento no puede exceder los 100 caracteres.")]
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Salario mensual del empleado en pesos colombianos.
    /// </summary>
    [Required(ErrorMessage = "Por favor indique el salario del empleado.")]
    [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
    public decimal Salary { get; set; }

    /// <summary>
    /// Fecha en la que el empleado fue contratado.
    /// </summary>
    [Required(ErrorMessage = "Por favor indique la fecha de contratación.")]
    public DateTime HiringDate { get; set; }

    /// <summary>
    /// Indica si el empleado sigue activo en la empresa.
    /// </summary>
    [Required]
    public bool IsActive { get; set; }
}
