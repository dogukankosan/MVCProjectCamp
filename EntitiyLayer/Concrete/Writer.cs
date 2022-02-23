using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete
{
    public class Writer
    {
        [Key]
        public short WriterID { get; set; }
        [StringLength(30)]
        public string WriterName { get; set; }
        [StringLength(30)]
        public string WriterSurName { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        [StringLength(200)]
        public string Mail { get; set; }
        [StringLength(150)]
        public string WriterAbout { get; set; }
        [StringLength(50)]
        public string WriterTitle { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        public bool Status { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
