using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiyLayer.Concrete
{
    public class About
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte AboutID { get; set; }
        [StringLength(250)]
        public string AboutDetails1 { get; set; }
        [StringLength(250)]
        public string AboutDetails2 { get; set; }
        [StringLength(150)]
        public string AboutImage1 { get; set; }
        [StringLength(150)]
        public string AboutImage2 { get; set; }
    }
}
