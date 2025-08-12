using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.Services
{
    internal class ApiConfigService(IPreferences preferences) : IApiConfigService
    {
        private readonly IPreferences _preferences = preferences;
        public string DefaultBaseAddress => "https://192.168.3.59:5106/";

        public string BaseAddress
        {
            get => _preferences.Get("api_base_address", DefaultBaseAddress);
            set => _preferences.Set("api_base_address", value);
        }
    }
}
