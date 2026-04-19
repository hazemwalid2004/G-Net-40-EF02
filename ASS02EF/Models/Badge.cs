using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class Badge
    {
        [Key]
        public int badgenumber {  get; set; }
        [DataType("datetime")]
        public DateTime issueDate {  get; set; }
        [Required]
        public tier tier { get; set; }
        [Required]  
        public Attendee badAttendee { get; set; }
        [ForeignKey(nameof(badAttendee))]
        public int attendeid { get; set; }


    }
}
