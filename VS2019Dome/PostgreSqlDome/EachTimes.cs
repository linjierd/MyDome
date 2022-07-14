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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlDome
{
    public partial class EachTimes : Form
    {
        public EachTimes()
        {
            InitializeComponent();
        }

        private void btn_confrom_Click(object sender, EventArgs e)
        {
            var t = tbx_Times.Text;
            int foreachTimes = 0;
            foreachTimes = Convert.ToInt32(t);
            InsertData(foreachTimes);
            this.Hide();
        }

        public static void InsertData(int foreachTimes)
        {
            NpgsqlParameter npgsql = new NpgsqlParameter("", NpgsqlDbType.Varchar, 50);
            try
            {
                
                Form1 form1 = new Form1();


                for (int i = 1; i <= foreachTimes; i++)
                {
                    //form1.tbx_Result.Text = $"正在循环第{i}次 \r\n";
                    var t1 = PostgreSqlCommon.ExecNonQueryBySql("update varcharLengthTest_varchar set dt=dt||'A';");
                    var t2 = PostgreSqlCommon.ExecNonQueryBySql("update varcharLengthTest_nvarchar set dt=dt||'啊';");
                    if (t1 > 0 && t2 > 0)
                    {
                        //form1.tbx_Result.Text += "pass";
                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("请填写次数");
            }
        }
    }
}
