using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using 雨季鳄龟交易分享平台.Models;

namespace 雨季鳄龟交易分享平台.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DbContext _db = new DbContext();
        private readonly IConfiguration _configuration;//添加的配置接口
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;//构造函数注入
        }

        string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };
        public IActionResult Login()
        {
            //获取用户IP
            string ip = Commond.GetHostAddress();

            #region (旧代码)聚合数据每天免费50次的次数. 超过就无法访问

            //JuHeApi juheApi = _configuration.GetSection("JuHeApi").Get<JuHeApi>();
            //HttpClientSample apiSample = new HttpClientSample(juheApi.Api);

            //var json = apiSample.Client("get", $"{juheApi.action}?ip={ip}&key={juheApi.Key}");
            //var ipModel = JsonConvert.DeserializeObject<Rootobject<IPModel>>(json)?.result;

            //if (ipModel?.Country != "中国")
            //{
            //    return Redirect("/Home/Error");
            //}
            #endregion

            #region 国外的IP跳转到错误页面

            HttpClientSample apiSample = new HttpClientSample("http://ip-api.com");
            var html= apiSample.Client("get", "json/" + ip + "?lang=zh-CN");
            //Newtonsoft.Json读取数据
            JObject obj = JsonConvert.DeserializeObject<JObject>(html);
            string country = obj["country"]?.ToString();
            if (country != "中国")
            {
                return Redirect("/Home/Error");
            }

            #endregion
            return View();
        }

        public bool Sign(string pwd)
        {
            var sign = _db.Db.Queryable<licenses>().Where(m => m.enable == true && m.key == pwd && m.available > m.used).First();
            if (sign!=null)
            {
                string ip = Commond.GetHostAddress();
                var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
                user.yj_UserName = "Admin";
                user.yj_UserAccount = sign.key;
                sign.used += 1;
                _db.Db.Updateable(user).ExecuteCommand();
                _db.Db.Updateable(sign).ExecuteCommand();
                return true;
            }
            return false;
        }
        
        public IActionResult Index()
        {
            //获取用户IP
            string ip = Commond.GetHostAddress();

            #region (旧代码)聚合数据每天免费50次的次数. 超过就无法访问

            //JuHeApi juheApi = _configuration.GetSection("JuHeApi").Get<JuHeApi>();
            //HttpClientSample apiSample = new HttpClientSample(juheApi.Api);

            //var json = apiSample.Client("get", $"{juheApi.action}?ip={ip}&key={juheApi.Key}");
            //var ipModel = JsonConvert.DeserializeObject<Rootobject<IPModel>>(json)?.result;

            //if (ipModel?.Country != "中国")
            //{
            //    return Redirect("/Home/Error");
            //}
            #endregion

            #region 国外的IP跳转到错误页面

            HttpClientSample apiSample = new HttpClientSample("http://ip-api.com");
            var html = apiSample.Client("get", "json/" + ip + "?lang=zh-CN");
            //Newtonsoft.Json读取数据
            JObject obj = JsonConvert.DeserializeObject<JObject>(html);
            string country = obj["country"]?.ToString();
            if (country != "中国")
            {
                return Redirect("/Home/Error");
            }

            #endregion

            #region IP登录

            //判断是否缓存用户信息
            var isLogin = new Yuji_User();
            try
            {
                isLogin = Cache.UserCache[ip];
            }
            catch { }
            if (isLogin==null||string.IsNullOrEmpty(isLogin.yj_IP))
            {
                var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
                if (user!=null)
                {
                    user.yj_lastLoginTime = DateTime.Now;
                    user.yj_LiginTimes += 1;
                    var rows = _db.Db.Updateable(user).ExecuteCommand();
                    Cache.UserCache.Add(ip,user);
                }
                else
                {
                    Yuji_User user1 = new Yuji_User()
                    {
                        yj_lastLoginTime = DateTime.Now,
                        yj_LiginTimes = 1,
                        yj_IP = ip,
                        yj_IsDelete = false
                    };
                    var rows= _db.Db.Insertable(user1).ExecuteCommand();
                    Cache.UserCache.Add(ip, user1);
                }
            }

            #endregion

            #region 查询乌龟销售列表

            //数据库获取出售列表
            var SellList = _db.Db.Queryable<YuJi_Sell>().Where(m=>m.yj_isDelete!=true).OrderBy(m=>m.yj_Time,SqlSugar.OrderByType.Desc).ToList();

            foreach (var item in SellList)
            {
                //匹配图片
                item.imgs = _db.Db.Queryable<YuJi_IMG>().Where(m => m.yj_SellId == item.yj_Id).ToList();

                //判断删除按钮出现的模块
                //判断是否是管理员或者是否是自己上传的
                var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);

                bool isDel = false;
                if (ip == item.yj_Uip || user.yj_UserName=="Admin" )
                {
                    isDel = true;
                } 

                item.yj_isDeleteBtn = isDel;
            }
            ViewBag.SellList = SellList;

            #endregion

            return View();
        }
        public IActionResult DetailInfo(string id)
        {
            var Info= _db.Db.Queryable<YuJi_Sell>().Single(m=>m.yj_Id==id);
            Info.imgs= _db.Db.Queryable<YuJi_IMG>().Where(m => m.yj_SellId == Info.yj_Id).ToList();
            ViewBag.Info = Info;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult UpdateLog()
        {
            return View();
        }

        public IActionResult DeleteInfo(string id)
        {
            var ip= Commond.GetHostAddress();

            var isAdmin = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);

            var sell = _db.Db.Queryable<YuJi_Sell>().Single(m=>m.yj_Id==id);

            if (isAdmin.yj_UserName=="Admin" || sell.yj_Uip==ip)
            {
                sell.yj_isDelete = true;
                _db.Db.Updateable(sell).ExecuteCommand();
                var imgs = _db.Db.Queryable<YuJi_IMG>().Where(m => m.yj_SellId == id).ToList();

                //_db.Db.Deleteable<YuJi_Sell>().In(id).ExecuteCommand();
                _db.Db.Deleteable<YuJi_IMG>().Where(m => m.yj_SellId == id).ExecuteCommand();

                foreach (var item in imgs)
                {
                    try
                    {

                        FileInfo file = new FileInfo($"D:\\yuji\\wwwroot\\{item.yj_ImgSrc}");
                        file.CopyTo($"D:\\yuji\\wwwroot\\backup\\{item.yj_ImgSrc}");
                        file.Delete();
                    }
                    catch (Exception)
                    {

                    }
                }

                return Redirect("/Home/index");
            }
            return Redirect("/Home/index");

        }

        public object ImgUpload()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            //size > 100MB refuse upload !
            if (size > 104857600)
            {
                return Json(Return_Helper_DG.Error_Msg_Ecode_Elevel_HttpCode("pictures total size > 100MB , server refused !"));
            }

            List<string> filePathResultList = new List<string>();

            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string filePath = Directory.GetCurrentDirectory() + $@"\wwwroot\Files\Pictures\";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string suffix = fileName.Split('.')[1];

                if (!pictureFormatArray.Contains(suffix))
                {
                    return Json(Return_Helper_DG.Error_Msg_Ecode_Elevel_HttpCode("the picture format not support ! you must upload files that suffix like 'png','jpg','jpeg','bmp','gif','ico'."));
                }

                fileName = Guid.NewGuid() + "." + suffix;

                string fileFullName = filePath + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                filePathResultList.Add($"/Files/Pictures/{fileName}");
            }

            string message = $"{files.Count} file(s) /{size} bytes uploaded successfully!";

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(message, filePathResultList, filePathResultList.Count));
        }
        public IActionResult AddSell(YuJi_Sell model)
        {
            string ip = Commond.GetHostAddress();
            var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
            model.yj_Uid = user.yj_Id;

            var sellId = Guid.NewGuid().ToString().Replace("-","");
            model.yj_Id = sellId;

            model.yj_Time = DateTime.Now;
            model.yj_Uip = ip;

            try
            {
                var srcs = model.yj_srcs.Split(',');
                if (srcs != null && srcs.Length > 0)
                {
                    List<YuJi_IMG> imgs = new List<YuJi_IMG>();
                    foreach (var item in srcs)
                    {
                        imgs.Add(new YuJi_IMG() { yj_SellId = sellId, yj_ImgSrc = item });
                    }
                    _db.Db.Insertable(imgs).ExecuteCommand();
                    _db.Db.Insertable(model).ExecuteCommand();
                    return Redirect("/Home/index");
                }
                else
                {
                    return Redirect("/Home/Add");
                }
            }
            catch (Exception)
            {

                return Redirect("/Home/Add");
            }
            
        }
    }
}
