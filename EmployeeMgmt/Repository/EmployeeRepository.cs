using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.DbContexts;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> Create(Employee employee)
        {
            try
            {
                _db.Employee.Add(employee);
                await _db.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw;
            }
        }

        public async Task<bool> Delete(int employeeID)
        {
            Employee employee = await _db.Employee.FirstOrDefaultAsync(e => e.Id == employeeID);
            if (employee == null)
            {
                return false;
            }

            try
            {
                _db.Employee.Remove(employee);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee> Get(int employeeID)
        {
            return await _db.Employee.FirstOrDefaultAsync(e => e.Id == employeeID);
        }

        public async Task<Employee> Update(Employee employee)
        {
            _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

    }
}
