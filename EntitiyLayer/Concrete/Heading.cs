using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete
{
    public class Heading
    {
        [Key]
        public short HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public byte CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Content> Contents { get; set; }
        public short WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
