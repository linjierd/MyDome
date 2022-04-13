using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using 聚合数据.Model;
using 聚合数据.Server;

namespace 聚合数据
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;//添加的配置接口
        public HostedServiceOptions HostedServiceOptions { get; private set; }//注入
        public JuHeDataOptions JuHeDataOptions { get; private set; }//注入




        //
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;//构造函数注入
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            HostedServiceOptions = _configuration.GetSection(HostedServiceOptions.HostedService).Get<HostedServiceOptions>(); //绑定并返回指定的类型
            JuHeDataOptions = _configuration.GetSection(JuHeDataOptions.JuHeData).Get<JuHeDataOptions>(); //绑定并返回指定的类型

            GetWeather weather = new GetWeather(JuHeDataOptions);
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                weather.RequestWeather();
                // 根据json文件配置来决定间隔时间
                await Task.Delay(HostedServiceOptions.WorkerInterval, stoppingToken);

            }
        }
        /// <summary>
        /// 重写BackgroundService.StartAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            HostedServiceOptions = _configuration.GetSection(HostedServiceOptions.HostedService).Get<HostedServiceOptions>(); //绑定并返回指定的类型

            _logger.LogInformation("Worker service starting at:{time},Intermittent time:" + HostedServiceOptions.WorkerInterval / 1000 + " second", DateTimeOffset.Now);

            await base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// 重写BackgroundService.StopAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service stopping at: {time}", DateTimeOffset.Now);

            await base.StopAsync(cancellationToken);
        }


    }
}
