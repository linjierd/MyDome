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
        #region 黑名单
        
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
                var data = db.Db.Queryable<BlackQQ>().OrderBy(m=>m.CreateTime,SqlSugar.OrderByType.Desc).ToList();
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
            var rows= db.Db.Deleteable<BlackQQ>().In(id).ExecuteCommand();
            return rows;

        }

        #endregion

        #region 警告禁言次数
        public IActionResult WarningTimes()
        {
            #region
            //获取用户IP
            string ip = Commond.GetHostAddress();
            DbContext dbMaster = new DbContext();
            var user = dbMaster.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
            bool isAdmin = user.yj_UserName == "Admin";
            #endregion

            #region 在SqlLite加载数据


            SqlConnection SqlConnection = _configuration.GetSection("SqlConnection").Get<SqlConnection>();
            DbContext db = new DbContext(SqlConnection.BlacklistPlugin, SqlSugar.DbType.Sqlite);
            var data = db.Db.Queryable<WarningTime>().OrderBy(m => m.LastTime, SqlSugar.OrderByType.Desc).ToList();
            ViewBag.WarningTimes = data;
            ViewBag.IsAdmin = isAdmin;
            #endregion
            return View();
        }

        public int DelWarningQQ(int id)
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
            return db.Db.Deleteable<WarningTime>().In(id).ExecuteCommand();
        }
        public int ClearWarning()
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

            var data = db.Db.Queryable<WarningTime>().ToList();
            foreach (var item in data)
            {
                item.WarningTimes = 0;
                item.LastTime = DateTime.Now;
            }
            return db.Db.Updateable(data).ExecuteCommand();
        }
        public int ClearGag()
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

            var data = db.Db.Queryable<WarningTime>().ToList();
            foreach (var item in data)
            {
                item.GagTimes = 0;
                item.LastTime = DateTime.Now;
            }
            return db.Db.Updateable(data).ExecuteCommand();
        }
        public int ClearAllData()
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
            return db.Db.Deleteable<WarningTime>().ExecuteCommand();
        }

        #endregion
    }
}
