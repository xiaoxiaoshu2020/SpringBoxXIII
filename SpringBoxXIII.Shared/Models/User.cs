using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Shared.Models
{
    public class User
    {
        public uint Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; } = string.Empty;
    }
}
