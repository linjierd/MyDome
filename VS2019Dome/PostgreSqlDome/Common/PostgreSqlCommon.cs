using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlDome.Common
{
    public class PostgreSqlCommon
    {
        static string connString = "Host=123.57.43.187;Port=5432;Username=postgres;Password=Zhang0418;Database=Dome;";

        public int ExecNonQueryBySql(string sql)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecNonQueryBySql(string sql, NpgsqlParameter parameter)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add(parameter);
                return cmd.ExecuteNonQuery();
            }
        }
        public DataSet QueryBySql(string sql)
        {
            var data = new DataSet();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var sda = new NpgsqlDataAdapter(sql, conn);
                sda.Fill(data);
            }
            return data;
        }

        public DataSet QueryBySql(string sql, NpgsqlParameter parameter)
        {
            var data = new DataSet();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add(parameter);
                var sda = new NpgsqlDataAdapter(cmd);
                sda.Fill(data);
            }
            return data;
        }

        public static (int,string) ExecNonQueryByFunction(string functionName, List<NpgsqlParameter> parameters)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(functionName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return (cmd.ExecuteNonQuery(),"Success");
                }
            }
            catch (Exception ex)
            {
                return (0,$"\r\n Message:{ex.Message}. \r\n InnerException:{ex.InnerException}");
            }
        }
        public static DataSet QueryByFunction(string sql, List<NpgsqlParameter> parameters)
        {
            var data = new DataSet();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                var sda = new NpgsqlDataAdapter(cmd);
                sda.Fill(data);
            }
            return data;
        }

    }
}
