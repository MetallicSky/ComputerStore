using CStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual string ClientName { get; set; }
        public virtual string Adress { get; set; }
        public virtual string ClientPhone { get; set; }
        public virtual int Count { get; set; }
        public virtual HomeController.Category Category { get; set; }

       
    }
}
