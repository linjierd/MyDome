using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS
{
    public class DbContext
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=123.57.43.187;Initial Catalog=Dome;User ID=sa;Pwd=Zhang0418",//链接字符串
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });

        }
        public DbContext(string ConnectionString, DbType dbType)
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,//链接字符串
                DbType = dbType,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
        }

        /// <summary>
        /// return DynamicSqlSugarClient
        /// </summary>
        /// <param name="strConnectionString">database connection string</param>
        /// <returns></returns>
        public SqlSugarClient DynamicSqlSugarClient(string strConnectionString)
        {

            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = strConnectionString,
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });


        }
        //注意：不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作



    }
}
