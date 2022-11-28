using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualtricsPOC.Interfaces
{
    public interface IHttpService
    {
        Task<string> Post(string uri, object data);
        Task<string> Put(string uri, object data);
        Task AuthPost(string uri);
    }
}
