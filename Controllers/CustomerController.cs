using CustomerManagement.Filters;
using CustomerManagement.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;


namespace CustomerManagement.Controllers
{
    [BasicAuth]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCustomers([DataSourceRequest] DataSourceRequest request)
        {
            var customers = _context.Customers;
            return Json(customers.ToDataSourceResult(request));
        }
        public IActionResult GetCountries()
        {
            var countries = _context.Customers
                .Select(c => c.Country)
                .Distinct()
                .OrderBy(c => c)
                .Select(c => new { Text = c, Value = c });

            return Json(countries);
        }


        [HttpPost]
        public IActionResult CreateCustomer([DataSourceRequest] DataSourceRequest request, Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }

            return Json(new[] { customer }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public IActionResult UpdateCustomer([DataSourceRequest] DataSourceRequest request, Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            return Json(new[] { customer }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public IActionResult DestroyCustomer([DataSourceRequest] DataSourceRequest request, Customer customer)
        {
            // Log the customer object
            Console.WriteLine($"DestroyCustomer called for Customer: Id={customer.CustomerId}, Name={customer.Name}, Email={customer.Email}, Country={customer.Country}");

            var entity = _context.Customers.Find(customer.CustomerId);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                _context.SaveChanges();
            }

            return Json(new[] { customer }.ToDataSourceResult(request, ModelState));
        }
    }
}
