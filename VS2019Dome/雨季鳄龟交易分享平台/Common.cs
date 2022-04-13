using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace 雨季鳄龟交易分享平台
{
    public class Common
    {
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {

            HttpContextAccessor context = new HttpContextAccessor();
            var ip = context.HttpContext?.Connection.RemoteIpAddress.ToString();
            return ip;
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }


    }
    public abstract class Return_Helper_DG
    {
        public static object IsSuccess_Msg_Data_HttpCode(bool isSuccess, string msg, dynamic data, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = isSuccess, msg = msg, httpCode = httpCode, data = data };
        }
        public static object Success_Msg_Data_DCount_HttpCode(string msg, dynamic data = null, int dataCount = 0, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = true, msg = msg, httpCode = httpCode, data = data, dataCount = dataCount };
        }
        public static object Error_Msg_Ecode_Elevel_HttpCode(string msg, int errorCode = 0, int errorLevel = 0, HttpStatusCode httpCode = HttpStatusCode.InternalServerError)
        {
            return new { isSuccess = false, msg = msg, httpCode = httpCode, errorCode = errorCode, errorLevel = errorLevel };
        }
    }
    public class HttpClientSample
    {
        public string _api { get; set; }

        public HttpClientSample(string api)
        {
            _api = api;
        }

        public string Client(string verbs, string uri, Object obj = null)
        {
            string json = "";
            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> task = null;
                //client.BaseAddress = new Uri($"{_api}/{uri}");
                if (verbs.Equals("get")) task = client.GetAsync($"{_api}/{uri}");
                if (verbs.Equals("post")) task = client.PostAsJsonAsync($"{_api}/{uri}", obj);
                task.Wait();
                HttpResponseMessage response = task.Result;
                if (response.IsSuccessStatusCode) json = response.Content.ReadAsStringAsync().Result;
            }
            return json;
        }
    }
}
