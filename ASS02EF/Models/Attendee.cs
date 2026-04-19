using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class Attendee
    {
        [Key]
        public int id{  get; set; }
        [Required]
        [MaxLength(50)]
        public string fullname { get; set; } = default!;
        [EmailAddress]
        public string email { get; set; }
        [MaxLength(60)]
        public Address homeaddress { get; set; }

        public Badge attBadge { get; set; }
        public ICollection<attendee_event> attendee_Events { get;set; }= new HashSet<attendee_event>();
    
    }
}
