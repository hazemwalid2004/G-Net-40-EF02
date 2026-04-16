using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class Event
    {
           public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int MaxAttendees { get; set; }


    }
}
