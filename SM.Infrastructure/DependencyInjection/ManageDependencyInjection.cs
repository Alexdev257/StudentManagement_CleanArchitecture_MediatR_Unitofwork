using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DependencyInjection
{
    public static class ManageDependencyInjection
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
            });
        }
    }
}
