using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackerApp.DI
{
    public static class DependencyinjectionContainer
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            try
            {
                //services.AddTransient<ITaskService, TaskService>();
                return services;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return services;
            }
        }
    }
}
