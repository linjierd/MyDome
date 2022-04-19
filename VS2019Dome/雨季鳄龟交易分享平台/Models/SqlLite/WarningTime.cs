using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雨季鳄龟交易分享平台.Models.SqlLite
{
    [SugarTable("WarningTimes")]
    public class WarningTime
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string QQ { get; set; }
        public int WarningTimes { get; set; }
        public int GagTimes { get; set; }
        public DateTime LastTime { get; set; }
    }
}
