using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class Motherboard
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Cost { get; set; }
        public virtual string Socket { get; set; }
        public virtual string Chipset { get; set; }
        public virtual  MBFormFactor FormFactor { get; set; }
        public virtual string Manufacturer { get; set; }

        public enum MBFormFactor
        {
            ATX,
            mATX,
            miniATX
        }
    }
}
