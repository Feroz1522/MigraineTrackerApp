using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackerApp.DI
{
    public static class StartUp
    {
        public static ServiceProvider ServiceProvider;
        public static IServiceProvider Init()
        {
            ServiceProvider initializedServiceProvider = new ServiceCollection()
                .ConfigureService()
                .BuildServiceProvider();
            return ServiceProvider = initializedServiceProvider;
        }
    }
}
