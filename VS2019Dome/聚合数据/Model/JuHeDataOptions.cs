using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚合数据.Model
{
    public class JuHeDataOptions
    {
        /// <summary>
        /// 这里要和appsetting里的数据是保持一致的
        /// </summary>
        public const string JuHeData = "JuHeData";
        public WeatherApi WeatherApi { get; set; }

    }
    public class WeatherApi
    {
        public string Api { get; set; }
        public string action { get; set; }
        public string DataType { get; set; }
        public string Key { get; set; }
        
        public string Citys { get; set; }
    }
    /// <summary>
    /// 聚合天气返回类
    /// </summary>
    public class JuheResponseModel
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string error_code { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public WeatherModel result { get; set; }
    }
    /// <summary>
    /// 天气
    /// </summary>
    public class WeatherModel
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 当前天气信息
        /// </summary>
        public realtime realtime { get; set; }
        /// <summary>
        /// 未来天气信息
        /// </summary>
        public List<future> future { get; set; }

    }
    /// <summary>
    /// 当前天气详情情况
    /// </summary>
    public class realtime
    {
        /// <summary>
        /// 温度，可能为空
        /// </summary>
        public int temperature { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public int humidity { get; set; }
        /// <summary>
        /// 天气情况，如：晴、多云
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 天气标识id，可参考小接口2
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// 风向，可能为空
        /// </summary>
        public string direct { get; set; }
        /// <summary>
        /// 风力，可能为空
        /// </summary>
        public string power { get; set; }
        /// <summary>
        /// 空气质量指数，可能为空
        /// </summary>
        public int aqi { get; set; }

    }
    /// <summary>
    /// 近5天天气情况
    /// </summary>
    public class future
    {
        /// <summary>
        /// 	日期
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 	温度，最低温/最高温
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 	天气情况
        /// </summary>
        public string weather { get; set; }
        public wid wid { get; set; }
        /// <summary>
        /// 	风向
        /// </summary>
        public string direct { get; set; }
    }
    public class wid
    {
        public int day { get; set; }
        public int night { get; set; }

    }
}
