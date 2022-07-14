using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS
{
    [SugarTable("SendSMSRule")]
    public class SendSMSRuleModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public int Weights { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Time { get; set; }
        public string Mobile { get; set; }
        public string UDF1 { get; set; }
        public bool IsEnable { get; set; }


    }



}
