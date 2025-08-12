using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.Services
{
    public interface IApiConfigService
    {
        string DefaultBaseAddress { get; }
        string BaseAddress { get; set; }
    }
}
