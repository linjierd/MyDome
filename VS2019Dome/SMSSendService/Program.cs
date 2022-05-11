using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using SMSSendService.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMSSendService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SMS.Send("����", "18649341891,15535420220");
            SMS.Send("�ܴ�", "18235491136", "���Ϲϵ�����Ԥ��");


            //    Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Information()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            //.Enrich.FromLogContext()
            //.WriteTo.Console() //����־�����������
            //.WriteTo.File(Directory.GetCurrentDirectory() + "\\logs\\LOG_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")//����־������ļ�
            //.CreateLogger();
            //    try
            //    {
            //        Log.Information("Starting Scale Handlefile of Windows Services");
            //        CreateHostBuilder(args).Build().Run();
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.Fatal(ex, "Scale Handlefile terminated unexpectedly:" + ex.Message);
            //    }
            //    finally
            //    {
            //        Log.Information("Ending Scale Handlefile of Windows Services");
            //        Log.CloseAndFlush();
            //    }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
