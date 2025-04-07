public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Salary = dto.Salary,
            IsActive = true
        };

        await _repository.AddAsync(employee);

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Salary = employee.Salary
        };
    }
}
