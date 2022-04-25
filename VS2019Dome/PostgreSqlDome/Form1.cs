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
            parameters.Add(new NpgsqlParameter("pa_mbooid", "test"));
            parameters.Add(new NpgsqlParameter("pa_dpt", 1));
            parameters.Add(new NpgsqlParameter("pa_pkmpst", DateTime.Now));
            parameters.Add(new NpgsqlParameter("pa_pkmpsr", "test"));
            parameters.Add(new NpgsqlParameter("pa_pkmusr", "test"));

            var tb = PostgreSqlCommon.QueryByFunction("p_buspkm", parameters).Tables[0];

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    tbx_Result.Text +=  $"|   {tb.Rows[i][j].ToString()}   |";
                }
                tbx_Result.Text += "\r\n";
            }


        }

    }
}
