using Microsoft.EntityFrameworkCore;

namespace Company.Services.Infrasctructure.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
