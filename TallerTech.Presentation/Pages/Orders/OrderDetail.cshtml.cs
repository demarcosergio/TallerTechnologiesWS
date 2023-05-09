using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Data.Entities;
using TallerTech.Presentation.Vms;

namespace TallerTech.Presentation.Orders
{
    public class OrderDetailModel : PageModel
    {
        private readonly TallerDbContext _context;

        public OrderDetailModel(TallerDbContext context)
        {
            _context = context;
        }

        public List<OrderDetailVm> Orders { get; set; }

        public void OnGet()
        {
            Orders = (from c in _context.Customers
                      join o in _context.Orders on c.PersonID equals o.PersonID
                      join od in _context.OrderDetails on o.OrderID equals od.OrderID
                      where od.ProductID == "1112222333"
                      select new OrderDetailVm
                      {
                          FullName = c.FirstName + " " + c.LastName,
                          Age = c.Age,
                          OrderID = o.OrderID,
                          DateCreated = o.DateCreated,
                          PurchaseMethod = o.MethodOfPurchase,
                          ProductNumber = od.ProductNumber,
                          ProductOrigin = od.ProductOrigin
                      }).ToList();
        }
    }
}
