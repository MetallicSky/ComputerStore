using CStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CStore.Controllers
{
    public class HomeController : Controller
    {

        private StoreDBContext db;
        

        public HomeController(StoreDBContext context)
        {
            db = context;
        }

        public IActionResult Index(string? category, string? amount,
            string? formFactor, string? bbFormFactor, int? minCost, int? maxCost, string? monufacturer)
        {
            if (category == null)
                category = "Видеокарты";
            switch (category)
            {
                case "Видеокарты":
                    ViewBag.Category = Category.GPU;
                    if (monufacturer == null)
                        monufacturer = "Выбрать все";
                    FilterGPU(monufacturer, maxCost, minCost);
                    break;
                case "Процессоры":
                    ViewBag.Category = Category.CPU;
                    if (monufacturer == null)
                        monufacturer = "Выбрать все";
                    FilterCPU(monufacturer, maxCost, minCost);
                    break;
                case "Материнские платы":
                    ViewBag.Category = Category.MotherBoard;
                    if (formFactor == null)
                        formFactor = "Выбрать все";
                    FilterMotherboard(formFactor, maxCost, minCost);
                    break;
                case "Оперативная память":
                    ViewBag.Category = Category.RAM;
                    if (amount == null)
                        amount = "Выбрать все";
                    FilterRAM(amount, maxCost, minCost);
                    break;
                case "Корпуса":
                    ViewBag.Category = Category.BodyBox;
                    if (bbFormFactor == null)
                        bbFormFactor = "Выбрать все";
                    FilterBodyBox(bbFormFactor, maxCost, minCost);
                    break;
            }
            if (maxCost != null)
                ViewBag.MaxCost = maxCost;

            if (minCost != null)
                ViewBag.MinCost = minCost;
            return View();
        }

        [HttpGet]
        public IActionResult Buy(Category category, int id)
        {
            ViewBag.Id = id;
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order model)
        {
            db.Orders.Add(new Order
            {
                Adress = model.Adress,
                Category = model.Category,
                ClientName = model.ClientName,
                ClientPhone = model.ClientPhone,
                Count = model.Count,
                ProductId = model.ProductId
            });
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private void FilterGPU(string monufacturer, int? maxCost, int? minCost)
        {
            List<GPU> gpus = new List<GPU>();
            switch (monufacturer)
            {   
                case "Выбрать все":
                    gpus = db.GPUs.ToList();
                    ViewBag.GPUFilter = 0;
                    break;
                case "AMD":
                    gpus = db.GPUs.Where(p => p.ChipManufacturer == GPU.GPUChipManufacturer.AMD).ToList();
                    ViewBag.GPUFilter = 1;
                    break;
                case "NVIDIA":
                    gpus = db.GPUs.Where(p => p.ChipManufacturer == GPU.GPUChipManufacturer.NVIDIA).ToList();
                    ViewBag.GPUFilter = 2;
                    break;
            }
            if (maxCost != null && minCost != null)
                ViewBag.GPUs = gpus.Where(p => p.Cost >= minCost && p.Cost <= maxCost).ToList();
            else if (maxCost != null)
                ViewBag.GPUs = gpus.Where(p => p.Cost <= maxCost).ToList();
            else if (minCost != null)
                ViewBag.GPUs = gpus.Where(p => p.Cost >= minCost).ToList();
            else
                ViewBag.GPUs = gpus;
        }

        private void FilterCPU(string monufacturer, int? maxCost, int? minCost)
        {
            List<CPU> cpus = new List<CPU>();
            switch (monufacturer)
            {
                case "Выбрать все":
                    cpus = db.CPUs.ToList();
                    ViewBag.CPUFilter = 0;
                    break;
                case "AMD":
                    cpus = db.CPUs.Where(p => p.Manufacturer == CPU.CPUChipManufacturer.AMD).ToList();
                    ViewBag.CPUFilter = 1;
                    break;
                case "Intel":
                    cpus = db.CPUs.Where(p => p.Manufacturer == CPU.CPUChipManufacturer.Intel).ToList();
                    ViewBag.CPUFilter = 2;
                    break;
            }
            if (maxCost != null && minCost != null)
                ViewBag.CPUs = cpus.Where(p => p.Cost >= minCost && p.Cost <= maxCost).ToList();
            else if (maxCost != null)
                ViewBag.CPUs = cpus.Where(p => p.Cost <= maxCost).ToList();
            else if (minCost != null)
                ViewBag.CPUs = cpus.Where(p => p.Cost >= minCost).ToList();
            else
                ViewBag.CPUs = cpus;
        }

        private void FilterMotherboard(string formFactor, int? maxCost, int? minCost)
        {
            List<Motherboard> mb = new List<Motherboard>();
            switch (formFactor)
            {
                case "Выбрать все":
                    mb = db.Motherboards.ToList();
                    ViewBag.MotherBoardFilter = 0;
                    break;
                case "ATX":
                    mb = db.Motherboards.Where(p => p.FormFactor == Motherboard.MBFormFactor.ATX).ToList();
                    ViewBag.MotherBoardFilter = 1;
                    break;
                case "mATX":
                    mb = db.Motherboards.Where(p => p.FormFactor == Motherboard.MBFormFactor.mATX).ToList();
                    ViewBag.MotherBoardFilter = 2;
                    break;
                case "miniATX":
                    mb = db.Motherboards.Where(p => p.FormFactor == Motherboard.MBFormFactor.miniATX).ToList();
                    ViewBag.MotherBoardFilter = 3;
                    break;
            }
            if (maxCost != null && minCost != null)
                ViewBag.Motherboards = mb.Where(p => p.Cost >= minCost && p.Cost <= maxCost).ToList();
            else if (maxCost != null)
                ViewBag.Motherboards = mb.Where(p => p.Cost <= maxCost).ToList();
            else if (minCost != null)
                ViewBag.Motherboards = mb.Where(p => p.Cost >= minCost).ToList();
            else
                ViewBag.Motherboards = mb;
        }

        private void FilterBodyBox(string formFactor, int? maxCost, int? minCost)
        {
            List<BodyBox> bb = new List<BodyBox>();
            switch (formFactor)
            {
                case "Выбрать все":
                    bb = db.BodyBoxes.ToList();
                    ViewBag.BodyBoxFilter = 0;
                    break;
                case "Desktop":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.Desktop).ToList();
                    ViewBag.BodyBoxFilter = 1;
                    break;
                case "MidiTower":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.MidiTower).ToList();
                    ViewBag.BodyBoxFilter = 4;
                    break;
                case "UltraTower":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.UltraTower).ToList();
                    ViewBag.BodyBoxFilter = 6;
                    break;
                case "MiniTower":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.MiniTower).ToList();
                    ViewBag.BodyBoxFilter = 5;
                    break;
                case "FullTower":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.FullTower).ToList();
                    ViewBag.BodyBoxFilter = 3;
                    break;
                case "CubeCase":
                    bb = db.BodyBoxes.Where(p => p.FormFactor == BodyBox.BBFormFactor.CubeCase).ToList();
                    ViewBag.BodyBoxFilter = 2;
                    break;
            }

            if (maxCost != null && minCost != null)
                ViewBag.BodyBoxes = bb.Where(p => p.Cost >= minCost && p.Cost <= maxCost).ToList();
            else if (maxCost != null)
                ViewBag.BodyBoxes = bb.Where(p => p.Cost <= maxCost).ToList();
            else if (minCost != null)
                ViewBag.BodyBoxes = bb.Where(p => p.Cost >= minCost).ToList();
            else
                ViewBag.BodyBoxes = bb;
        }
        private void FilterRAM(string amount, int? maxCost, int? minCost)
        {
            List<RAM> rams = new List<RAM>();
            switch (amount)
            {
                case "Выбрать все":
                    rams = db.RAMs.ToList();
                    ViewBag.RAMFilter = 0;
                    break;
                case "1024":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT1GB).ToList();
                    ViewBag.RAMFilter = 1;
                    break;
                case "2048":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT2GB).ToList();
                    ViewBag.RAMFilter = 2;
                    break;
                case "4096":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT4GB).ToList();
                    ViewBag.RAMFilter = 3;
                    break;
                case "8192":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT8GB).ToList();
                    ViewBag.RAMFilter = 4;
                    break;
                case "16_384":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT16GB).ToList();
                    ViewBag.RAMFilter = 5;
                    break;
                case "32_768":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT32GB).ToList();
                    ViewBag.RAMFilter = 6;
                    break;
                case "65_536":
                    rams = db.RAMs.Where(p => p.Amount == RAM.AMOUNT64GB).ToList();
                    ViewBag.RAMFilter = 7;
                    break;
            }
            if (maxCost != null && minCost != null)
                ViewBag.RAMs = rams.Where(p => p.Cost >= minCost && p.Cost <= maxCost).ToList();
            else if (maxCost != null)
                ViewBag.RAMs = rams.Where(p => p.Cost <= maxCost).ToList();
            else if (minCost != null)
                ViewBag.RAMs = rams.Where(p => p.Cost >= minCost).ToList();
            else
                ViewBag.RAMs = rams;
        }


        public enum Category
        {
            BodyBox,
            CPU,
            GPU,
            RAM,
            MotherBoard
        }
    }
}
