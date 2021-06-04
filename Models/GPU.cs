using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class GPU
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int MemoryAmount { get; set; }
        public virtual int ClockSpeed { get; set; }
        public virtual int Bus { get; set; }
        public virtual int Cost { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual GPUChipManufacturer ChipManufacturer { get; set; }

        public enum GPUChipManufacturer
        {
            AMD,
            NVIDIA
        }
    }

    
}
