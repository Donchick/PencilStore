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

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Column("Buyers")]
        public virtual ICollection<BuyerEntity> Buyers { get; set; }
    }
}