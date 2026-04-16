using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF.Models
{
    internal class Orginazer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = default!;
        [MaxLength(50)]
        public string companyname { get; set; }
        [DataType("boolean")]
        public Boolean isverfied { get; set; }
        public Profile orgprofile   { get; set; }
    }
}
