using CStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private StoreDBContext db;

        public AdminController(StoreDBContext db)
        {
            this.db = db;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            ViewBag.GPUs = db.GPUs.ToList();
            ViewBag.CPUs = db.CPUs.ToList();
            ViewBag.Motherboards = db.Motherboards.ToList();
            ViewBag.BodyBoxes = db.BodyBoxes.ToList();
            ViewBag.RAMs = db.RAMs.ToList();
            ViewBag.Orders = db.Orders.ToList();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Admin admin = await db.Admins.FirstOrDefaultAsync(u =>
                u.Login == model.Login && u.Password == model.Password);
                if (admin != null)
                {
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string adminName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, adminName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin")
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AddBodyBox()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddBodyBox(BodyBox model)
        {
            db.BodyBoxes.Add(new BodyBox
            {
                Name = model.Name,
                FormFactor = model.FormFactor,
                Color = model.Color,
                Cost = model.Cost,
                Manufacturer = model.Manufacturer
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddGPU()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddGPU(GPU model)
        {
            db.GPUs.Add(new GPU
            {
                Name = model.Name,
                MemoryAmount = model.MemoryAmount,
                ClockSpeed = model.ClockSpeed,
                Bus = model.Bus,
                Cost = model.Cost,
                ChipManufacturer = model.ChipManufacturer,
                Manufacturer = model.Manufacturer
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddCPU()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddCPU(CPU model)
        {
            db.CPUs.Add(new CPU
            {
                Name = model.Name,
                ClockSpeed = model.ClockSpeed,
                Socket = model.Socket,
                Cores = model.Cores,
                Cost = model.Cost,
                Manufacturer = model.Manufacturer
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddRAM()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddRAM(RAM model)
        {
            db.RAMs.Add(new RAM
            {
                Name = model.Name,
                Amount = model.Amount,
                Cost = model.Cost,
                Type = model.Type,
                Manufacturer = model.Manufacturer
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AddMotherboard()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddMotherboard(Motherboard model)
        {
            db.Motherboards.Add(new Motherboard
            {
                Manufacturer = model.Manufacturer,
                Cost = model.Cost,
                Chipset = model.Chipset,
                FormFactor = model.FormFactor,
                Name = model.Name,
                Socket = model.Socket
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteGPU(int id)
        {
            var gpu = await db.GPUs.FirstOrDefaultAsync(p => p.Id == id);
            if (gpu != null)
                db.GPUs.Remove(gpu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCPU(int id)
        {
            var cpu = await db.CPUs.FirstOrDefaultAsync(p => p.Id == id);
            if (cpu != null)
                db.CPUs.Remove(cpu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRAM(int id)
        {
            var mb = await db.RAMs.FirstOrDefaultAsync(p => p.Id == id);
            if (mb != null)
                db.RAMs.Remove(mb);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMotherboard(int id)
        {
            var mb = await db.Motherboards.FirstOrDefaultAsync(p => p.Id == id);
            if (mb != null)
                db.Motherboards.Remove(mb);

            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBodyBox(int id)
        {
            var bb = await db.BodyBoxes.FirstOrDefaultAsync(p => p.Id == id);
            if (bb != null)
                db.BodyBoxes.Remove(bb);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditBodyBox(int id)
        {
            return View(db.BodyBoxes.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult EditBodyBox(BodyBox model)
        {
            db.BodyBoxes.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditGPU(int id)
        {
            return View(db.GPUs.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult EditGPU(GPU model)
        {
            db.GPUs.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditCPU(int id)
        {
            return View(db.CPUs.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult EditCPU(CPU model)
        {
            db.CPUs.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditRAM(int id)
        {
            return View(db.RAMs.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult EditRAM(RAM model)
        {
            db.RAMs.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditMotherboard(int id)
        {
            return View(db.Motherboards.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult EditMotherboard(Motherboard model)
        {
            db.Motherboards.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}