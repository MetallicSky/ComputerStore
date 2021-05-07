using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class RAM
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual RAMType Type { get; set; }
        public virtual int Amount { get; set; }
        public virtual int Cost { get; set; }
        public virtual string Manufacturer { get; set; }

        public enum RAMType
        {
            DDR2,
            DDR3,
            DDR4
        }

        public const int AMOUNT1GB = 1024;
        public const int AMOUNT2GB = 2048;
        public const int AMOUNT4GB = 4096;
        public const int AMOUNT8GB = 8192;
        public const int AMOUNT16GB = 16_384;
        public const int AMOUNT32GB = 32_768;
        public const int AMOUNT64GB = 65_536;
    }

    

    
}
