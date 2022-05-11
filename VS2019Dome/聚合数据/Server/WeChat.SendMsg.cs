using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 聚合数据.Common;

namespace 聚合数据.Server
{
    public class WeChat
    {
        public static void SendMsg()
        {
            HttpClientSample apiSample = new HttpClientSample("https://qyapi.weixin.qq.com");
            string GetToken = apiSample.Client("get", "cgi-bin/gettoken?corpid=wwfec1206c26125777&corpsecret=SpXscTFmWY0AAWHi-yHGazNbfgw-0uetkahnOCMszO8");
            JObject obj = JsonConvert.DeserializeObject<JObject>(GetToken);
            string access_token = obj["access_token"]?.ToString();

            var data = new SendMsgModel() { text = new text() { content = "test msg" } };
            var json = JsonConvert.SerializeObject(data);
            var result= apiSample.Client("post", $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + access_token, json);


        }




    }
    public class SendMsgModel
    {

        public string touser { get; set; } = "ZhangLinJie";
        public string msgtype { get; set; } = "text";
        public string agentid { get; set; } = "1000002";
        public text text { get; set; }
    }
    public class text
    {
        public string content { get; set; }
    }

}
