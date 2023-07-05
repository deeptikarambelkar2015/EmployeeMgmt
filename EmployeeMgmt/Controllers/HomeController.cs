using EmployeeMgmt.Models;
using EmployeeMgmt.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace EmployeeMgmt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = (List<Employee>)await _employeeRepository.Get();
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            return View("Edit",employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            return View("Delete", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Employee employee)
        {
          
                await _employeeRepository.Delete(employee.Id);
                return RedirectToAction("Index");
         
        }
        public async Task<IActionResult> Details(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            return View("Details", employee);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}