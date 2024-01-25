using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

    }
}
