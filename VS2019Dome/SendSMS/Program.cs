using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SendSMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console() //����־�����������
        .WriteTo.File(Directory.GetCurrentDirectory() + "\\logs\\LOG_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")//����־������ļ�
        .CreateLogger();
            try
            {
                Log.Information("Starting Scale Handlefile of Windows Services");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Scale Handlefile terminated unexpectedly:" + ex.Message);
            }
            finally
            {
                Log.Information("Ending Scale Handlefile of Windows Services");
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()//֧��Windows����
             .UseSerilog()//����Serilog���滻��΢���Դ���NLOG����
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
