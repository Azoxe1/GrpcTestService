using Grpc.Core;
using GrpcService.Protos;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GrpcService.Services
{
    public class TestService : Test.TestBase
    {
        private readonly ILogger<TestService> _logger;
        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public async override Task<InfoReply> GetInfo(InfoReply request, ServerCallContext context)
        {
            InfoReply reply = new InfoReply();
            string connStr = "server=localhost;user=c_azoxe;database=testdb;password=3543;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = $"SELECT name, age FROM info_2 WHERE id = {request.Id}";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    string n = reader.GetString(0);
                    int a = reader.GetInt32(1);
                    reply = new InfoReply
                    {
                        Name = n,
                        Age = a
                    };
                }
                return await Task.FromResult(reply);
            }
        }

        public override async Task<InfoReply> InsertInfo(InfoReply request, ServerCallContext context)
        {
            InfoReply reply = new InfoReply();
            string connStr = "server=localhost;user=c_azoxe;database=testdb;password=3543;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = $"INSERT INTO info_2 (id, name, age) VALUES (@value1,'{request.Name}',@value3)"; /*попробовать*/
                comm.Parameters.AddWithValue("@value1", request.Id);
                //comm.Parameters.AddWithValue("@value2", request.Name);
                comm.Parameters.AddWithValue("@value3", request.Age);

                comm.ExecuteNonQuery();
                return await Task.FromResult(reply);
            }
        }

        public override async Task<InfoReply> DeleteInfo(InfoReply request, ServerCallContext context)
        {
            InfoReply reply = new InfoReply();
            string connStr = "server=localhost;user=c_azoxe;database=testdb;password=3543;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = $"DELETE FROM info_2 WHERE id = {request.Id}";
                comm.ExecuteNonQuery();
                return await Task.FromResult(reply);
            }
        }

        public override async Task<InfoReply> ChangeInfo(InfoReply request, ServerCallContext context)
        {
            InfoReply reply = new InfoReply();
            string connStr = "server=localhost;user=c_azoxe;database=testdb;password=3543;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = $"UPDATE info_2 SET name=@name, age=@age WHERE id=@id";
                comm.Parameters.AddWithValue("@id", request.Id);
                comm.Parameters.AddWithValue("@name", request.Name);
                comm.Parameters.AddWithValue("@age", request.Age);
                comm.ExecuteNonQuery();
                return await Task.FromResult(reply);
            }
        }
    }
}
