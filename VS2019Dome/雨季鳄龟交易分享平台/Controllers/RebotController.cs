using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 雨季鳄龟交易分享平台.Models;
using 雨季鳄龟交易分享平台.Models.SqlLite;

namespace 雨季鳄龟交易分享平台.Controllers
{
    public class RebotController : Controller
    {

        private readonly IConfiguration _configuration;//添加的配置接口
        public RebotController(IConfiguration configuration)
        {
            _configuration = configuration;//构造函数注入
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlakList()
        {
            try
            {

                #region 验证管理员身份

                //获取用户IP
                string ip = Commond.GetHostAddress();
                DbContext dbMaster = new DbContext();
                var user = dbMaster.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
                bool isAdmin = user.yj_UserName == "Admin";
                #endregion

                #region 在SqlLite加载数据


                SqlConnection SqlConnection = _configuration.GetSection("SqlConnection").Get<SqlConnection>();
                DbContext db = new DbContext(SqlConnection.BlacklistPlugin, SqlSugar.DbType.Sqlite);
                var data = db.Db.Queryable<BlackQQ>().ToList();
                ViewBag.BlackQQ = data;
                ViewBag.IsAdmin = isAdmin;
                #endregion
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public int DelBlackQQ(int id)
        {
            #region 验证管理员身份

            //获取用户IP
            string ip = Commond.GetHostAddress();
            DbContext dbMaster = new DbContext();
            var user = dbMaster.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);

            if (user.yj_UserName != "Admin")
            {
                return -1;
            }
            #endregion

            SqlConnection SqlConnection = _configuration.GetSection("SqlConnection").Get<SqlConnection>();
            DbContext db = new DbContext(SqlConnection.BlacklistPlugin, SqlSugar.DbType.Sqlite);
            return db.Db.Deleteable<BlackQQ>().In(id).ExecuteCommand();
        }
    }
}
