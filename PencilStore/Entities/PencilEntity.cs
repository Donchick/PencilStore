using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PencilStore.Entities
{
    [Table("Pencils")]
    public class PencilEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PencilId { get; set; }

        public string Name { get; set; }

        public string Descritpion { get; set; }

        public byte Image { get; set; }

        public decimal Price { get; set; }

        [Column("Buyers")]
        public virtual ICollection<BuyerEntity> Buyers { get; set; }
    }
}