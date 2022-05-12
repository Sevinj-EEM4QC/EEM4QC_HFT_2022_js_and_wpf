using EEM4QC_HFT_2021221.Endpoint;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace EEM4QC_HFT_2021221.Endpoint
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method which create host and run it
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(10000);
            CreateHostBuilder(args).Build().Run();

        }
        /// <summary>
        /// Create host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}