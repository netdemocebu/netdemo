using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace NetDemo.Repositories
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            MyDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<MyDbContext>();

            context.SaveChanges();
        }
    }
}
