using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PencilStore.Models
{
    public class Buyer
    {
        public int BuyerId { get; set; }

        public string Name { get; set; }
        
        public virtual IEnumerable<Pencil> Pencils { get; set; }
    }
}