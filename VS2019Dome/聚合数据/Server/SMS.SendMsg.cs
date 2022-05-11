using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 聚合数据.Common;

namespace 聚合数据.Server
{
    public static class SMS
    {
        public static void Send()
        {
            


            SendMsg("2683", DateTime.Now.ToString("yyyyMMddHHmmss"), "", "");
        }
        public static void SendMsg(string userid, string timestamp, string mobile, string content, string sendTime= "", string action= "send", string extno="")
        {
            HttpClientSample apiSample = new HttpClientSample("http://120.77.80.125:8888/v2sms.aspx");
            string AppKey = "testmima20120701231212";
            string md5 = EncrypHelper.encrypt(AppKey);

            var data = new {
                userid = userid,
                timestamp = timestamp,
                sign = md5,
                mobile = mobile,
                content = content,
                sendTime = sendTime,
                action = action,
                extno = extno
            };

            var result= apiSample.Client("post", "", data);
        }
    }
}
