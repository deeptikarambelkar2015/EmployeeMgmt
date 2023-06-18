using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();

        Task<Employee> Get(int Id);

        Task<Employee> Create(Employee employee);

        Task<Employee> Update(Employee employee);

        Task<bool> Delete(int phoneId);
    }
}
