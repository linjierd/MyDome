using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsByFramework4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_page_Click(object sender, EventArgs e)
        {

            string connectionString = "";
            string strWhere = " funurl<>'#' ";
            int count = 0;
            int pagecount = 0;

            var tablename = "fun";
            var fields = " ID,FUNNAM,FUNURL,case when FUNFLG=1 then '是' else '否' end FUNFLG,FUNUSR,FUNORD,FUNSTM,FUNRMK ";
            var pageIndex = 1;
            var pageSize = 10;
            var Condition = "";
            var Orders = "";


            DataSet ds = null;
            NpgsqlParameter[] para =
            {
                new NpgsqlParameter("@pa_sTable",NpgsqlDbType.Varchar,50),
                new NpgsqlParameter("@pa_sField",NpgsqlDbType.Varchar,2000),
                new NpgsqlParameter("@pa_iPageCurr",NpgsqlDbType.Integer),
                new NpgsqlParameter("@pa_iPageSize",NpgsqlDbType.Integer),
                new NpgsqlParameter("@pa_sCondition",NpgsqlDbType.Varchar,500),
                new NpgsqlParameter("@pa_sOrder",NpgsqlDbType.Varchar,100)
            };
            para[0].Value = tablename;
            para[1].Value = fields;
            para[2].Value = pageIndex;
            para[3].Value = pageSize;
            para[4].Value = Condition;
            para[5].Value = Orders;
            //para[6].Direction = ParameterDirection.Output;
            //para[7].Direction = ParameterDirection.Output;
            //para[8].Direction = ParameterDirection.Output;
            DataSet result = new DataSet();
           // result = DbHelperSQL.RunProcedure1("BEGIN;SELECT wms_getlistforpage(@pa_sTable,@pa_sField,@pa_iPageCurr,@pa_iPageSize,@pa_sCondition,@pa_sOrder,'a','b','c');FETCH all in \"a\";FETCH all in \"b\"; FETCH all in \"c\"; commit;", para);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                NpgsqlDataAdapter sqlDA = new NpgsqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, tablename, para);
                sqlDA.Fill(dataSet);
                connection.Close();
                //return dataSet;
            }

            //Counts = Convert.ToInt32(para[6].Value);
            //pageCount = Convert.ToInt32(para[7].Value);
            var Counts = Convert.ToInt32(result.Tables[1].Rows[0]["count"]);
           var  pageCount = Convert.ToInt32(result.Tables[2].Rows[0]["pa_pageCount"]);
            ds.Tables.Add(result.Tables[3]);
        }
        /// <summary>
        /// 构建 NpgsqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>NpgsqlCommand</returns>
        private static NpgsqlCommand BuildQueryCommand(NpgsqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 36000;
            if (parameters != null)
            {
                foreach (NpgsqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }

            return command;
        }
    }
}
