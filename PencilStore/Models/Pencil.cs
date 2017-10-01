using System.Collections.Generic;

namespace PencilStore.Models
{
    public class Pencil
    {
        public int PencilId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
        
        public IEnumerable<int> BuyersIds { get; set; }
    }
}