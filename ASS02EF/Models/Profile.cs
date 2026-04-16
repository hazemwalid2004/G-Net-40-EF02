using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class Profile
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string biography { get; set; }
        [Url]
        public string website { get; set; }
        [Url]
        public string logo { get; set; }
        [Required]
        public Orginazer proOrginazer { get; set; }
        [ForeignKey(nameof(proOrginazer))]
        public int orginazerID { get; set; }
    }
}
