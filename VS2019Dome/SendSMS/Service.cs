using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS
{
    public class Service
    {
        private DbContext _db = new DbContext();

        public static void SendMsg(string userid, string timestamp, string mobile, string content, string sendTime = "", string action = "send", string extno = "")
        {
            string AppKey = "1864934189118649341891" + timestamp;
            string md5 = EncrypHelper.MD5Encrypt32(AppKey).ToLower();//生成令牌
            HttpClientSample apiSample = new HttpClientSample("http://120.77.80.125:8888");
            var para = $"action={action}&userid={userid}&timestamp={timestamp}&sign={md5.ToLower()}&mobile={mobile}&content={content}&sendTime={sendTime}&extno={extno}";//配置短信的规则
            var result = apiSample.Client("post", $"v2sms.aspx?{para}");//发送短信
            Log.Information($"Send to {mobile} completed");//记录日志
        }

        public void Send()
        {
            var ruleList = _db.Db.Queryable<SendSMSRuleModel>().Where(m=>m.IsEnable==true).ToList();
            foreach (var item in ruleList)
            {
                var RuleTime = item.Time;
                if (RuleTime == DateTime.Now.ToString("HHmm"))
                {
                    var lastlog = _db?.Db?.Queryable<SendSMSLogModel>().Where(m => item.Time == DateTime.Parse(m.LastSendTime).ToString("HHmm") && m.Title == item.Title)?.ToList();
                    if (lastlog == null || lastlog.Count <= 0)
                    {
                        var text = SMSEdit(item);

                        SendMsg("2683", DateTime.Now.ToString("yyyyMMddHHmmss"), item.Mobile, text);//发送短信的方法

                        SendSMSLogModel log = new SendSMSLogModel()
                        {
                            LastSendTime = DateTime.Now.ToString(),
                            Title = item.Title,
                            Success = "Y",
                            SendInfo = text,
                            MSG = "Sended success"
                        };

                        _db.Db.Insertable(log).ExecuteCommand();
                    }
                }
            }

        }
        public string SMSEdit(SendSMSRuleModel item)
        {
            var text = $"【{item.Title}】{item.Info}";
            if (text.IndexOf("[天气预报]")>=0)
            {
                text = text.Replace("[天气预报]", WeatherText(item));
            }

            return text;
            
        }

        public string WeatherText(SendSMSRuleModel item)
        {
            HttpClientSample apiSample = new HttpClientSample("http://apis.juhe.cn");//配置天气预报的接口
            var json = apiSample.Client("get", $"simpleWeather/query?city={item.UDF1}&key=8c6d3e443345f2da7ce5098116098521");//查询天气预报
            var result = JsonConvert.DeserializeObject<JuheResponseModel>(json);//获取天气预报的结果
            WeatherModel weather = new WeatherModel();
            weather = result.result;

            //以下是拼接天气预报的短信内容
            var text = $"{weather.city}现在{weather.realtime.info},{weather.realtime.direct} {weather.realtime.power},空气质量指数{weather.realtime.aqi},温度{weather.realtime.temperature},湿度{weather.realtime.humidity}.\n";
            foreach (var future in weather.future)
            {
                text += $"{DateDiff(future.date)}:{future.weather},{future.direct}.温度{future.temperature}.\n";
            }
            return text;
        }
        public static string DateDiff(string para)
        {
            try
            {
                DateTime date = Convert.ToDateTime(para);
                var diff = (date - Convert.ToDateTime(DateTime.Now.ToShortDateString())).Days;
                if (diff == 0) return "今天";
                if (diff == 1) return "明天";
                if (diff == 2) return "后天";
                return date.ToShortDateString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
