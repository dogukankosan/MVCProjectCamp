using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiyLayer.Concrete
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(250)]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public ICollection<Heading> Headings { get; set; }
    }
}
