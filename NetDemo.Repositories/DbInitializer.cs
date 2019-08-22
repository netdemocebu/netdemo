using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetDemo.Models;
using System.Threading.Tasks;

namespace NetDemo.Repositories
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            DemoContext context = applicationBuilder.ApplicationServices.GetRequiredService<DemoContext>();

            context.SaveChanges();
        }
    }
}
