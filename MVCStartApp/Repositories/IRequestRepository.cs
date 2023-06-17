using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(string requestUrl);
        Task<Request[]> GetRequests();
    }
}
