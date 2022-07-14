using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using 雨季鳄龟交易分享平台;
using 雨季鳄龟交易分享平台.Models;

namespace NetCoreMVC.Controllers
{
    public class DeceptiveController : Controller
    {

        DbContext _db = new DbContext();
        private readonly ILogger<DeceptiveController> _logger;
        private readonly IConfiguration _configuration;//添加的配置接口
        public DeceptiveController(IConfiguration configuration)
        {
            _configuration = configuration;//构造函数注入
        }

        string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };

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

            //HttpClientSample apiSample = new HttpClientSample("http://ip-api.com");
            //var html = apiSample.Client("get", "json/" + ip + "?lang=zh-CN");
            ////Newtonsoft.Json读取数据
            //JObject obj = JsonConvert.DeserializeObject<JObject>(html);
            //string country = obj["country"]?.ToString();
            //if (country != "中国")
            //{
            //    return Redirect("/Home/Error");
            //}

            #endregion


            #region 查询骗子列表

            //数据库获取骗子列表
            var DeceList = _db.Db.Queryable<YuJi_Deceptiver>().Where(m => m.yj_isDelete != true).OrderBy(m => m.yj_Time, SqlSugar.OrderByType.Desc).ToList();

            foreach (var item in DeceList)
            {
                //匹配图片
                item.imgs = _db.Db.Queryable<YuJi_Deceptiver_IMG>().Where(m => m.yj_DeceptiverId == item.yj_Id.ToString()).ToList();

                //判断删除按钮出现的模块
                //判断是否是管理员或者是否是自己上传的
                var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);

                bool isDel = false;
                if (ip == item.yj_Uip || user.yj_UserName == "Admin")
                {
                    isDel = true;
                }

                item.yj_isDeleteBtn = isDel;
            }
            ViewBag.DeceList = DeceList;

            #endregion



            return View();
        }

        public IActionResult Add()
        {
            return View();
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

                string filePath = Directory.GetCurrentDirectory() + $@"\wwwroot\Files\DeceptiverPictures\";

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
                filePathResultList.Add($"/Files/DeceptiverPictures/{fileName}");
            }

            string message = $"{files.Count} file(s) /{size} bytes uploaded successfully!";

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(message, filePathResultList, filePathResultList.Count));
        }
        public IActionResult AddDeceptiver(YuJi_Deceptiver model)
        {
            string ip = Commond.GetHostAddress();
            var user = _db.Db.Queryable<Yuji_User>().Single(m => m.yj_IP == ip);
            model.yj_Uid = user.yj_Id;

            var yj_DeceptiverId = Guid.NewGuid().ToString().Replace("-", "");
            model.yj_Id = yj_DeceptiverId;

            model.yj_Time = DateTime.Now;
            model.yj_Uip = ip;

            try
            {
                var srcs = model.yj_srcs.Split(',');
                if (srcs != null && srcs.Length > 0)
                {
                    List<YuJi_Deceptiver_IMG> imgs = new List<YuJi_Deceptiver_IMG>();
                    foreach (var item in srcs)
                    {
                        imgs.Add(new YuJi_Deceptiver_IMG() { yj_DeceptiverId = yj_DeceptiverId, yj_ImgSrc = item });
                    }
                    _db.Db.Insertable(imgs).ExecuteCommand();
                    _db.Db.Insertable(model).ExecuteCommand();
                    return Redirect("/Deceptive/index");
                }
                else
                {
                    return Redirect("/Deceptive/Add");
                }
            }
            catch (Exception)
            {

                return Redirect("/Deceptive/Add");
            }

        }
        public IActionResult DetailInfo(string id)
        {
            var Info = _db.Db.Queryable<YuJi_Deceptiver>().Single(m => m.yj_Id == id);
            Info.imgs = _db.Db.Queryable<YuJi_Deceptiver_IMG>().Where(m => m.yj_DeceptiverId == Info.yj_Id).ToList();
            ViewBag.Info = Info;

            return View();
        }
    }
}
