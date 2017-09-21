using DevopsAssignmentPrimeCheck.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevopsAssignmentPrimeCheck.Middleware
{
    public static class PrimeCheckerExtension
    {
        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
          PrimeCheckerOption options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            var primeService = builder.ApplicationServices.GetService(typeof(PrimeService)) as PrimeService;
            return builder.Use(next => new PrimeCheckerMiddleware(next, options, primeService).Invoke);
        }

        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
            PathString path)
        {
            return UsePrimeChecker(builder, new PrimeCheckerOption { Path = path });
        }
        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
            string path)
        {
            return UsePrimeChecker(builder, new PrimeCheckerOption { Path = new PathString(path) });
        }

        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder)
        {
            return UsePrimeChecker(builder,
                new PrimeCheckerOption()
                {
                    Path = new PathString("/checkprime")
                });
        }
    }
}
