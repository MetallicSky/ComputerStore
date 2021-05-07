using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class CPU
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int ClockSpeed { get; set; }
        public virtual int Cores { get; set; }
        public virtual int Cost { get; set; }
        public virtual int Socket { get; set; }
        public virtual CPUChipManufacturer Manufacturer { get; set; }


        public enum CPUChipManufacturer
        {
            AMD,
            Intel
        }
    }
}
