using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete
{
    public class Contact
    {
        [Key]
        public short ContactID { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(250)]
        public string ContentText { get; set; }
        [DefaultValue("getutcdate()")]
        public DateTime Date { get; set; }
        public bool Read { get; set; }
    }
}
