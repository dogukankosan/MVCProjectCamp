using System;
using System.ComponentModel.DataAnnotations;
namespace EntitiyLayer.Concrete
{
    public class Content
    {
        [Key]
        public short ContentID { get; set; }
        public string ContentText { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public short HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
        public short? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
