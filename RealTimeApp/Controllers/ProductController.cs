using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeApp.Hubs;
using RealTimeApp.Models;

namespace RealTimeApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopingContext context;
        private readonly IHubContext<ProductHub> hubContext;

        public ProductController(ShopingContext context,IHubContext<ProductHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View(context.Product.ToList());
        }
        public IActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        public IActionResult New(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                context.SaveChanges();

                hubContext.Clients.All.SendAsync("AddProductNotify", product);//obj .net
                
                return RedirectToAction("Index");
            }
            return View(product);

        }

    }
}
