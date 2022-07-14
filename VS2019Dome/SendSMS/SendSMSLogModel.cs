using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS
{
    
        [SugarTable("SendSMSLog")]
    class SendSMSLogModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public string Title { get; set; }
        public string LastSendTime { get; set; }
        public string Success { get; set; }
        public string SendInfo { get; set; }
        public string MSG  { get; set; }
    }
}
