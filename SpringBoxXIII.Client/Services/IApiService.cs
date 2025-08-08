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
        public Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string key);
    }
}
