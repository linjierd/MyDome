using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雨季鳄龟交易分享平台.Models
{

    public class Rootobject<T>
    {
        public string resultcode { get; set; }
        public string reason { get; set; }
        public T result { get; set; }
        public int error_code { get; set; }
    }

    public class Result
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Isp { get; set; }
    }

}
