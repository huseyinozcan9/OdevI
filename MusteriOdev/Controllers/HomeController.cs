using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusteriOdev.Models;
using MusteriOdev.Models.DTO;
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
 

            var employees = await _nwContext.Employees
                                          .Include(employee => employee.Orders)
                                          .ThenInclude(order => order.OrderDetails)
                                          .ThenInclude(orderdetails => orderdetails.Product)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync(m => m.EmployeeId == id);

            //var result = from e in _nwContext.Employees 
            //             join o in _nwContext.Orders
            //             on e.EmployeeId equals o.EmployeeId
            //             join od in _nwContext.OrderDetails
            //             on o.OrderId equals od.OrderId
            //             where e.EmployeeId == id
            //             select e;
                      
            return View(employees);
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