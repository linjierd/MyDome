using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SMSSendService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SMSSendService.Model;

namespace SMSSendService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;//��ӵ����ýӿ�
        public HostedServiceOptions HostedServiceOptions { get; private set; }//ע��



        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;//���캯��ע��
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            HostedServiceOptions = _configuration.GetSection(HostedServiceOptions.HostedService).Get<HostedServiceOptions>(); //�󶨲�����ָ��������
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //SMS.Send();
                //����json�ļ��������������ʱ��
                await Task.Delay(HostedServiceOptions.WorkerInterval, stoppingToken);
            }

        }
        /// <summary>
        /// ��дBackgroundService.StartAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            HostedServiceOptions = _configuration.GetSection(HostedServiceOptions.HostedService).Get<HostedServiceOptions>(); //�󶨲�����ָ��������

            _logger.LogInformation("Scale handleFile service starting at:{time},Intermittent time:" + HostedServiceOptions.WorkerInterval / 1000 + " second", DateTimeOffset.Now);

            await base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// ��дBackgroundService.StopAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Scale handleFile service stopping at: {time}", DateTimeOffset.Now);

            await base.StopAsync(cancellationToken);
        }

    }
}
