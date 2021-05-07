using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class BodyDox
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual BBFormFactor FormFactor { get; set; }
        public virtual BBColor Color { get; set; }
        public virtual int Cost { get; set; }
        public virtual string Manufacturer { get; set; }

        public enum BBFormFactor
        {
            Desktop,
            MidiTower,
            UltraTower,
            MiniTower,
            FullTower,
            CubeCase
        }

        public enum BBColor
        {
            White,
            Black
        }
    }
}
