using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiyLayer.Concrete
{
    public class Gallery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte ID { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
        [StringLength(350)]
        public string ImagePath { get; set; }
    }
}
