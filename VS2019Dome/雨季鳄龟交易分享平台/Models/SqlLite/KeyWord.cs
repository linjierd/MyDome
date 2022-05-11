using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVC.Models.SqlLite
{
    [SugarTable("BlackKeyword")]
    public class KeyWord
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string Keyword { get; set; }
        public PunishTypeDB PunishTypeDB { get; set; }
        public DateTime CreateTime { get; set; }

    }

    public enum PunishTypeDB
    {
        扣积分=1,
        禁言=2,
        警告=3
    }
}
