using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiyLayer.Concrete
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public short ID { get; set; }
        [StringLength(70)]
        public string Sender { get; set; }
        [StringLength(70)]
        public string Receiver { get; set; }
        [StringLength(70)]
        public string Subject { get; set; }
        public string ContextText { get; set; }
        [DefaultValue("getutcdate()")]
        public DateTime MessageDate { get; set; }
        public bool ReadStatus { get; set; }
        public bool Status { get; set; }
    }
}
