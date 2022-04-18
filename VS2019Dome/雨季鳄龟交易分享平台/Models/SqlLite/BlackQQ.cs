using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雨季鳄龟交易分享平台.Models.SqlLite
{
    [SugarTable("BlackQQ")]
    public class BlackQQ
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string QQ { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
