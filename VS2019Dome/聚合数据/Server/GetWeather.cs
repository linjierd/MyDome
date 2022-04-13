using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 聚合数据.Common;
using 聚合数据.Model;

namespace 聚合数据.Server
{
    public class GetWeather
    {
        private readonly ILogger log = Log.Logger;
        public JuHeDataOptions _JuHeDataOptions { get; set; }

        public GetWeather(JuHeDataOptions juHeDataOptions)
        {
            _JuHeDataOptions = juHeDataOptions;
        }

        private GetWeather() { }

        public void RequestWeather()
        {
            try
            {
                var citys = _JuHeDataOptions.WeatherApi.Citys.Split(',');
                HttpClientSample apiSample = new HttpClientSample(_JuHeDataOptions.WeatherApi.Api);
                if (citys!=null&& citys.Length>0)
                {
                    foreach (var city in citys)
                    {
                        var json = apiSample.Client("get", $"{_JuHeDataOptions.WeatherApi.action}?city={city}&key={_JuHeDataOptions.WeatherApi.Key}");
                        var result = JsonConvert.DeserializeObject<JuheResponseModel>(json);

                        SqlHelper _db = new SqlHelper("Data Source=123.57.43.187;Initial Catalog=Dome;User ID=sa;Pwd=Zhang0418");


                        var realtime = result.result.realtime;

                        var timespan = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                        string realtimeSql = $"INSERT INTO [Dome].[dbo].[realtime]([city],[time],[timespan],[temperature],[humidity],[info],[wid],[direct],[power],[aqi]) VALUES ('{city}','{DateTime.Now}','{timespan}','{realtime.temperature}','{realtime.humidity}','{realtime.info}','{realtime.wid}','{realtime.direct}','{realtime.power}','{realtime.aqi}')";
                        var sqlExe = _db.ExecuteSql(realtimeSql);
                        if (sqlExe>0)
                        {
                            var futureData = result.result.future;

                            StringBuilder futureSql = new StringBuilder();
                            futureSql.Append("INSERT INTO [Dome].[dbo].[future]([city],[time],[timespan],[date],[temperature],[weather],[widDay],[widNight],[direct]) VALUES ");

                            for (int i = 0; i < futureData.Count; i++)
                            {
                                futureSql.Append($"('{city}','{DateTime.Now}','{timespan}','{futureData[i].date}','{futureData[i].temperature}','{futureData[i].weather}','{futureData[i].wid.day}','{futureData[i].wid.night}','{futureData[i].direct}')");

                                if(i+1 < futureData.Count)
                                {
                                    futureSql.Append(",");
                                }
                            }

                            var futureSqlExec= _db.ExecuteSql(futureSql.ToString());
                            if (futureSqlExec>0)
                            {
                                log.Information("Success");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
