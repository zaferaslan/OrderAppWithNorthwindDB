using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAppWithNorthwindDB.Models;

namespace OrderAppWithNorthwindDB.Controllers
{
    public class OrderController : Controller
    {
        private readonly NORTHWNDContext _context;
        public OrderController(NORTHWNDContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Order> orderList = new List<Order>();
            orderList = _context.Orders.Include(a => a.Employee).Include(b => b.Customer).ToList();
            return View(orderList);
        }

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            orderDetailList = _context.OrderDetails.Include(a=>a.Product).Where(a=>a.OrderId == id).ToList();
            return View(orderDetailList);
        }

    }
}
