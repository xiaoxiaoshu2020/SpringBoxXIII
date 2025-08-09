using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.Services
{
    public interface IApiService
    {
        public Task<string> GetAsync(string endpoint);
        public Task<string> PostAsync<TRequest>(string endpoint, TRequest data);
    }
}
