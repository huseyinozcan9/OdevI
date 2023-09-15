using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusteriOdev.Models;
using System.Diagnostics;

namespace MusteriOdev.Controllers
{
    public class HomeController : Controller
    {

        public NorthwindContext _nwContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, NorthwindContext nwContext)
        {
            _logger = logger;
            _nwContext = nwContext;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _nwContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // GET: Employee/OrderDetails/id
        public async Task<IActionResult> OrderDetails(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _nwContext.Employees
                                          .Include(employee => employee.Orders)
                                          .ThenInclude(order => order.OrderDetails)
                                          .ThenInclude(orderdetails => orderdetails.Product)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }
        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Title")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _nwContext.Add(employee);
                await _nwContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {

            var employee = await _nwContext.Employees.FindAsync(id);
            _nwContext.Employees.Remove(employee);
            await _nwContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}