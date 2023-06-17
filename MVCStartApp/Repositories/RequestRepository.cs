using Microsoft.EntityFrameworkCore;
using MVCStartApp.Contexts;
using MVCStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext context;
        public RequestRepository(BlogContext blogContext)
        {
            this.context = blogContext;
        }
        public async Task AddRequest(string requestUrl)
        {
            Request request = new Request()
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = requestUrl
            };
            
            var entry = context.Entry(request);
            if (entry.State == EntityState.Detached)
                await context.Requests.AddAsync(request);

            await context.SaveChangesAsync();
        }
        public async Task<Request[]> GetRequests()
        {
            return await context.Requests.ToArrayAsync();
        }
    }
}
