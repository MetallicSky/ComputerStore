using CStore.Models;
using System.Linq;


namespace CStore
{
    public class TableFiller
    {
        private StoreDBContext db;
        public TableFiller(StoreDBContext db)
        {
            this.db = db;
        }
        public void Init()
        {
            if (!db.Admins.Any())
            {
                db.Admins.Add(new Admin {Login = "admin", Password = "admin" });
                db.SaveChanges();
            }

            if (!db.CPUs.Any()) 
            {
                db.CPUs.AddRange(
                    new CPU
                    {
                        Cost = 9000,
                        ClockSpeed = 3500,
                        Cores = 4,
                        Manufacturer = CPU.CPUChipManufacturer.AMD,
                        Socket = "am3+",
                        Name = "fx-8320"
                    },
                    new CPU
                    {
                        Cost = 12000,
                        ClockSpeed = 3620,
                        Cores = 4,
                        Manufacturer = CPU.CPUChipManufacturer.Intel,
                        Socket = "lga-1155",
                        Name = "i5-8325"
                    },
                    new CPU
                    {
                        Cost = 17000,
                        ClockSpeed = 3720,
                        Cores = 6,
                        Manufacturer = CPU.CPUChipManufacturer.AMD,
                        Socket = "am4",
                        Name = "Rizen 2366"
                    },
                    new CPU
                    {
                        Cost = 9000,
                        ClockSpeed = 3720,
                        Cores = 2,
                        Manufacturer = CPU.CPUChipManufacturer.Intel,
                        Socket = "lga-1150",
                        Name = "i3 8290"
                    },
                     new CPU
                     {
                         Cost = 29000,
                         ClockSpeed = 4300,
                         Cores = 8,
                         Manufacturer = CPU.CPUChipManufacturer.Intel,
                         Socket = "lga-1150",
                         Name = "i7 3029"
                     });
                db.SaveChanges();
            }

            if (!db.GPUs.Any())
            {
                db.GPUs.AddRange(
                    new GPU
                    {
                        Cost = 16900,
                        ChipManufacturer = GPU.GPUChipManufacturer.NVIDIA,
                        Manufacturer = "msi",
                        ClockSpeed = 925,
                        Name = "gtx 780",
                        Bus = 128,
                        MemoryAmount = 4
                    },
                    new GPU
                    {
                        Cost = 12900,
                        ChipManufacturer = GPU.GPUChipManufacturer.AMD,
                        Manufacturer = "aser",
                        ClockSpeed = 915,
                        Name = "Radeon R9 270",
                        Bus = 256,
                        MemoryAmount = 2
                    },

                    new GPU
                    {
                        Cost = 9500,
                        ChipManufacturer = GPU.GPUChipManufacturer.NVIDIA,
                        Manufacturer = "asus",
                        ClockSpeed = 915,
                        Name = "GTX 1030",
                        Bus = 128,
                        MemoryAmount = 2
                    },
                    new GPU
                    {
                        Cost = 9800,
                        ChipManufacturer = GPU.GPUChipManufacturer.AMD,
                        Manufacturer = "palit",
                        ClockSpeed = 900,
                        Name = "GTX 1030",
                        Bus = 128,
                        MemoryAmount = 2
                    });
                db.SaveChanges();
            }

            if (!db.RAMs.Any())
            {
                db.RAMs.AddRange(
                    new RAM
                    {
                        Name = "3df2324",
                        Amount = RAM.AMOUNT16GB,
                        Cost = 9000,
                        Type = RAM.RAMType.DDR4,
                        Manufacturer = "samsung"
                    },
                    new RAM
                    {
                        Name = "ere232",
                        Amount = RAM.AMOUNT4GB,
                        Cost = 2500,
                        Type = RAM.RAMType.DDR3,
                        Manufacturer = "samsung"
                    },
                    new RAM
                    {
                        Name = "qwt3x",
                        Amount = RAM.AMOUNT2GB,
                        Cost = 1500,
                        Type = RAM.RAMType.DDR2,
                        Manufacturer = "samsung"
                    },
                    new RAM
                    {
                        Name = "qwt3x",
                        Amount = RAM.AMOUNT64GB,
                        Cost = 16000,
                        Type = RAM.RAMType.DDR4,
                        Manufacturer = "samsung"
                    });
                db.SaveChanges();
            }

            if (!db.BodyBoxes.Any())
            {
                db.BodyBoxes.AddRange(
                    new BodyBox
                    {
                        Name = "z11plus",
                        Cost = 6000,
                        FormFactor = BodyBox.BBFormFactor.MidiTower,
                        Color = BodyBox.BBColor.Black,
                        Manufacturer = "zulman"
                    },
                    new BodyBox
                    {
                        Name = "z9",
                        Cost = 3500,
                        FormFactor = BodyBox.BBFormFactor.MidiTower,
                        Color = BodyBox.BBColor.White,
                        Manufacturer = "zulman"
                    },
                    new BodyBox
                    {
                        Name = "z10plus",
                        Cost = 12000,
                        FormFactor = BodyBox.BBFormFactor.CubeCase,
                        Color = BodyBox.BBColor.White,
                        Manufacturer = "zulman"
                    },
                    new BodyBox
                    {
                        Name = "z3plus",
                        Cost = 4000,
                        FormFactor = BodyBox.BBFormFactor.MiniTower,
                        Color = BodyBox.BBColor.Black,
                        Manufacturer = "zulman"
                    },
                    new BodyBox
                    {
                        Name = "krisa",
                        Cost = 7000,
                        FormFactor = BodyBox.BBFormFactor.Desktop,
                        Color = BodyBox.BBColor.Black,
                        Manufacturer = "cucushka"
                    });
                db.SaveChanges();
            }

            if (!db.Motherboards.Any())
            {
                db.Motherboards.AddRange(
                    new Motherboard
                    {
                        Name = "awe1231fdsdf",
                        Cost = 12000,
                        Chipset = "e22",
                        FormFactor = Motherboard.MBFormFactor.ATX,
                        Manufacturer = "msi",
                        Socket = "am4"
                    },
                    new Motherboard
                    {
                        Name = "43ee",
                        Cost = 6000,
                        Chipset = "e22",
                        FormFactor = Motherboard.MBFormFactor.mATX,
                        Manufacturer = "asus",
                        Socket = "am3+"
                    },

                    new Motherboard
                    {
                        Name = "432ee",
                        Cost = 5000,
                        Chipset = "e22",
                        FormFactor = Motherboard.MBFormFactor.ATX,
                        Manufacturer = "asus",
                        Socket = "am4"
                    },
                    new Motherboard
                    {
                        Name = "quuue123",
                        Cost = 15000,
                        Chipset = "e22",
                        FormFactor = Motherboard.MBFormFactor.mATX,
                        Manufacturer = "asus",
                        Socket = "am4"
                    });
                db.SaveChanges();
            }



        }

    }
}
