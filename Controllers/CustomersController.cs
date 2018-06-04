using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {


            var customers = _context.Customers.Include(customer => customer.MembershipType).ToList();



            return View(customers);
        }


        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {

            //var customer = _context.Customers.Include(c => c.MembershipType).ToList().Find(customer1 => customer1.Id.Equals(id));
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customer1 => customer1.Id.Equals(id));


            return View(customer);
        }
    }
}