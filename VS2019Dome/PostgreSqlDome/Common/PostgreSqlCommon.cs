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
        static string connString = "Host=123.57.43.187;Port=5432;Username=postgres;Password=Zhang0418;Database=postgres;";

        public static int ExecNonQueryBySql(string sql)
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

        public static (int, string) ExecNonQueryByFunction(string functionName, List<NpgsqlParameter> parameters)
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
                    return (cmd.ExecuteNonQuery(), "Success");
                }
            }
            catch (Exception ex)
            {
                return (0, $"\r\n Message:{ex.Message}. \r\n InnerException:{ex.InnerException}");
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
        public static DataSet QueryByFunction(string sql, NpgsqlParameter[] parameters)
        {
            var data = new DataSet();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                var sda = new NpgsqlDataAdapter(cmd);
                sda.Fill(data);
            }
            return data;
        }

        public static DataSet RefCursorFunc(string sql, NpgsqlParameter[] parameters=null)
        {
            var data = new DataSet();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters!=null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                NpgsqlTransaction t = conn.BeginTransaction();
                try
                {
                    cmd.ExecuteNonQuery();

                    var p = parameters[0].NpgsqlValue;
                    //NpgsqlDataReader rd = (NpgsqlDataReader)cmd.Parameters["p"].NpgsqlValue;
                    //rd.Read();
                    //rd.GetValue(0);
                }
                catch (NpgsqlException ex)
                {
                    t.Rollback();
                    conn.Close();
                }
                finally
                {
                    t.Commit();
                    conn.Close();
                }
            }
            return data;
        }

        public static DataSet QueryBySql(string sql, NpgsqlParameter[] parameters)
        {

            var data = new DataSet();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddRange(parameters);
                    var sda = new NpgsqlDataAdapter(cmd);
                    sda.Fill(data);
                }
            }
            catch (NpgsqlException ex)
            {
                var err = ex.Message;
            }
            
            return data;
        }

        public static (int, string) ExecNonQueryByProc(string functionName, NpgsqlParameter[] paras = null)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(functionName, conn);
                    cmd.Parameters.AddRange(paras);
                    return (cmd.ExecuteNonQuery(), "Success");
                }
            }
            catch (Exception ex)
            {
                return (0, $"\r\n Message:{ex.Message}. \r\n InnerException:{ex.InnerException}");
            }
        }
        public static object FunctionResultOutput()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("my_fun", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new NpgsqlParameter("p_out", DbType.String) { Direction = ParameterDirection.Output });
                cmd.ExecuteNonQuery();
                return cmd.Parameters[0].Value;
            }
        }

        public static object ProcedureResultOutput()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("call my_proc(@p_out)", conn);
                    cmd.Parameters.Add(new NpgsqlParameter("@p_out", DbType.String) { Value = '2', Direction = ParameterDirection.InputOutput });
                    cmd.ExecuteNonQuery();
                    return cmd.Parameters[0].Value;
                }
            }
            catch (Exception ex )
            {
                return ex.Message;
            }
            
        }


    }
    public class PgSqlCursor:System.Object
    {

    }
}
