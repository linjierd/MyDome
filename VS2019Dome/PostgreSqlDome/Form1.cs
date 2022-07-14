using Npgsql;
using NpgsqlTypes;
using PostgreSqlDome.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlDome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ExecPostgreSqlFunction_Click(object sender, EventArgs e)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter("@painput", NpgsqlDbType.Numeric, 50));
            //parameters[0].Value = "123";
            //parameters.Add(new NpgsqlParameter("@painput", "123"));
            //parameters.Add(new NpgsqlParameter("pa_dpt", 1));
            //parameters.Add(new NpgsqlParameter("pa_pkmpst", DateTime.Now));
            //parameters.Add(new NpgsqlParameter("pa_pkmpsr", "test"));
            //parameters.Add(new NpgsqlParameter("pa_pkmusr", "test"));

            var tb = PostgreSqlCommon.QueryByFunction("returnsvalue", parameters).Tables[0];

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    tbx_Result.Text +=  $"|   {tb.Rows[i][j].ToString()}   |";
                }
                tbx_Result.Text += "\r\n";
            }


        }

        private void tbn_Proc_Click(object sender, EventArgs e)
        {
            NpgsqlParameter[] parameters = new NpgsqlParameter[3] {
             new NpgsqlParameter("@para1", NpgsqlDbType.Varchar, 50),
             new NpgsqlParameter("@para2", NpgsqlDbType.Varchar, 50),
             new NpgsqlParameter("@ref1", NpgsqlDbType.Refcursor),
            };
            parameters[0].Value = "datapara1" + DateTime.Now.ToString("yyyyMMddHHmmss");
            parameters[1].Value = "datapara2" + DateTime.Now.ToString("yyyyMMddHHmmss");
            parameters[2].Value = "a";
            parameters[2].Direction = ParameterDirection.Output;
            var result = PostgreSqlCommon.ExecNonQueryByProc("call testproc(@para1,@para2,@ref1);", parameters);
            var cur = parameters[2].Value;



            //NpgsqlParameter[] parameters = new NpgsqlParameter[1] {
            // new NpgsqlParameter("p", NpgsqlDbType.Refcursor),
            //};
            //parameters[0].Direction = ParameterDirection.Output;
            //PostgreSqlCommon.RefCursorFunc("refcursorfunc", parameters);


            //DataSet ds = null;
            //NpgsqlParameter[] para =
            //{
            //    new NpgsqlParameter("@pa_sTable",NpgsqlDbType.Varchar,50),
            //    new NpgsqlParameter("@pa_sField",NpgsqlDbType.Varchar,2000),
            //    new NpgsqlParameter("@pa_iPageCurr",NpgsqlDbType.Integer),
            //    new NpgsqlParameter("@pa_iPageSize",NpgsqlDbType.Integer),
            //    new NpgsqlParameter("@pa_sCondition",NpgsqlDbType.Varchar,500),
            //    new NpgsqlParameter("@pa_sOrder",NpgsqlDbType.Varchar,100),
            //};
            //para[0].Value = "dpt";
            //para[1].Value = "*";
            //para[2].Value = 2;
            //para[3].Value = 3;
            //para[4].Value = "";
            //para[5].Value = "";
            ////para[6].Direction = ParameterDirection.Output;
            ////para[7].Direction = ParameterDirection.Output;
            ////para[8].Direction = ParameterDirection.Output;

            //var s= PostgreSqlCommon.QueryBySql("BEGIN;SELECT wms_getlistforpage(@pa_sTable,@pa_sField,@pa_iPageCurr,@pa_iPageSize,@pa_sCondition,@pa_sOrder,'a','b','c');FETCH all in \"a\";FETCH all in \"b\"; FETCH all in \"c\"; commit;", para);


        }

        private void btn_InsertData_Click(object sender, EventArgs e)
        {

        }


        private void btn_Proc_Result_Click(object sender, EventArgs e)
        {
            NpgsqlParameter[] parameters = new NpgsqlParameter[2] {
             new NpgsqlParameter("@para1", NpgsqlDbType.Varchar, 50),
             new NpgsqlParameter("@result1", NpgsqlDbType.Integer),
            };
            parameters[0].Value = "datapara1" + DateTime.Now.ToString("yyyyMMddHHmmss");
            parameters[1].Value = 0;
            parameters[1].Direction = ParameterDirection.Output;
            var result = PostgreSqlCommon.ExecNonQueryByProc("call testprocResultInt(@para1,@result1);", parameters);
            var cur = parameters[1].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result= PostgreSqlCommon.FunctionResultOutput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = PostgreSqlCommon.ProcedureResultOutput();
            tbx_Result.Text = result.ToString();

        }
    }
}

