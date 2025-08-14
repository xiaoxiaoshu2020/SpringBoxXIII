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
        public uint UserId { get; set; }
        [StringLength(10)]
        public string UserName { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
