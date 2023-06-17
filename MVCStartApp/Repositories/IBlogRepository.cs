using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
