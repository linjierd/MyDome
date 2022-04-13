using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雨季鳄龟交易分享平台.Models
{
    public class Cache
    {
        public static Dictionary<string, Yuji_User> UserCache = new Dictionary<string, Yuji_User>();
    }
    [SugarTable("YuJi_licenses")]
    public class licenses
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public string key { get; set; }
        public int available { get; set; }
        public int used { get; set; }
        public bool enable { get; set; }
    }



    [SugarTable("Yuji_User")]
    public class Yuji_User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int yj_Id { get; set; }
        public string yj_UserName { get; set; }
        public string yj_UserAccount { get; set; }
        public string yj_Pwd { get; set; }
        public string yj_IP { get; set; }
        public bool yj_sign { get; set; }
        public DateTime yj_lastLoginTime { get; set; }
        public int yj_LiginTimes { get; set; }
        public bool yj_IsDelete { get; set; }
    }

    [SugarTable("YuJi_Sell")]
    public class YuJi_Sell
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string yj_Id { get; set; }
        public int yj_Uid { get; set; }
        public string yj_Title { get; set; }
        public DateTime yj_Time { get; set; }

        public string yj_Uip { get; set; }
        public string yj_Desc { get; set; }
        public string yj_WeiXin { get; set; }
        public string yj_QQ { get; set; }
        public decimal yj_price { get; set; }
        public bool yj_isDelete { get; set; }
        [SugarColumn(IsIgnore = true)]
        public bool yj_isDeleteBtn { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<YuJi_IMG> imgs { get; set; }
        [SugarColumn(IsIgnore = true)]
        public bool IsDeleteBtn { get; set; }
        [SugarColumn(IsIgnore = true)]
        public string yj_srcs { get; set; }
    }

    [SugarTable("YuJi_IMG")]
    public class YuJi_IMG
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity =true)]
        public int yj_Id { get; set; }
        public string yj_SellId { get; set; }
        public string yj_ImgSrc { get; set; }
    }
}
