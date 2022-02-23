using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiyLayer.Concrete
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte ID { get; set; }
        [StringLength(50)]
        public string UserNameAdmin { get; set; }
        [StringLength(75)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string PasswordAdmin { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
