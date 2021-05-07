using CStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace CStore.Controllers
{
    public class HomeController : Controller
    {

        private Store db;
        

        public HomeController(Store context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            //var mPlate = new Category { Name = "Mother plate" };
            //var vCard = new Category { Name = "Video card" };
            //var processor = new Category { Name = "Processor" };

            //db.Categories.AddRange(mPlate, vCard, processor);

            //var daniel = new Client { Name = "Daniel", Email = "den228@gmail.com", PhoneNumber = "123323123123" };
            //var patrush = new Client { Name = "Patrush", Email = "prush322@gmail.com", PhoneNumber = "7653242" };
            //var cumDiller = new Client { Name = "Cum Diller", Email = "cumzone@gachi.com", PhoneNumber = "3228551488" };

            //db.Clients.AddRange(daniel, patrush, cumDiller);

            //var fx8320 = new Product { Category = processor, Name = "fx-8320", Price = 2_000,
            //    Quantity = 20, ProductState = Product.State.InStock };

            //db.Products.AddRange(fx8320);

            //var firstOrder = new Order
            //{
            //    Product = fx8320,
            //    Quantity = 1,
            //    Client = cumDiller,
            //    Date = DateTime.Now
            //};

            //db.Orders.AddRange(firstOrder);

            //db.SaveChanges();

            //DebugPageModel model = new DebugPageModel
            //{
            //    Clients = db.Clients.ToList(),
            //    Products = db.Products.ToList(),
            //    Categories = db.Categories.ToList(),
            //    Orders = db.Orders.ToList(),
            //    DebugStr = Environment.CurrentDirectory
            //};

            //foreach(var client in db.Clients)
            //    Debug.WriteLine(client.Name);

            //foreach (var client in db.Categories)
            //    Debug.WriteLine(client.Name);

            //foreach (var client in db.Products)
            //    Debug.WriteLine(client.Name);

            return View(/*model*/);
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }


    }
}
