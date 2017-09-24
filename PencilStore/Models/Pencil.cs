using System.Collections.Generic;

namespace PencilStore.Models
{
    public class Pencil
    {
        public int PencilId { get; set; }

        public string Name { get; set; }

        public string Descritpion { get; set; }

        public byte Image { get; set; }

        public decimal Price { get; set; }
        
        public IEnumerable<int> BuyersIds { get; set; }
    }
}