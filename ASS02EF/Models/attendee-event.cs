using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class attendee_event
    {
        public int Attendeeid {  get; set; }
        public Attendee Attendee { get; set; }
        public int Eventid { get; set; }
        public Event Event { get; set; }
    }
}
