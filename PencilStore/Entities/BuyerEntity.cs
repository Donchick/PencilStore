using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PencilStore.Entities
{
    [Table("Buyers")]
    public class BuyerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("Pencils")]
        public virtual ICollection<PencilEntity> Pencils { get; set; }
    }
}