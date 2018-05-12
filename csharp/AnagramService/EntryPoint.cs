using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AnagramService
{
    /// <summary>
    /// This class serves as the entry point of the service
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// The Main function to be invoked during startup
        /// </summary>
        /// <param name="args">Any arguments passed to startup</param>
        public static void Main(string[] args)
        {
            Anagrams.Init();//Force C# to call the static constructor now

            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:8080/")
                .Build();
    }
}
