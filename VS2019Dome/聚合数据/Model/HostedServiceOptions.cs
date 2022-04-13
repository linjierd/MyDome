using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚合数据.Model
{
    public class HostedServiceOptions
    {
        /// <summary>
        /// 这里要和appsetting里的数据是保持一致的
        /// </summary>
        public const string HostedService = "HostedService";

        /// <summary>
        /// 间隔运行的时间,单位毫秒
        /// </summary>
        public int WorkerInterval { get; set; }
    }

}
