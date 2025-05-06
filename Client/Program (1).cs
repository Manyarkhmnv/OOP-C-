using Npgsql;
using Test.Models;

string connectionString = "Server=localhost;Port=5432;User Id=Masha;Password=123;Database=Lab5";
string sql = "select json_build_object(\n\t'Users', json_agg(\n\t\tjson_build_object('UserFullname', u.\"Fullname\", 'UserId', u.\"Id\", 'UserPin', u.\"Pin\",\n\t\t\t'UserOrders',  ( \n\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t'OrderId', uo.\"Id\", 'OrderBalance', uo.\"Balance\",\n\t\t \t\t\t\t\t\t'Operations', (\n\t\t \t\t\t\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t\t\t\t'OperationId', o.\"Id\",\n\t\t \t\t\t\t\t\t\t\t\t'OperationFullname', o.\"Operation_name\",\n\t\t \t\t\t\t\t\t\t\t\t'OperationAmount', o.\"Amount\"\n\t\t \t\t\t\t\t\t\t\t)\n\t\t \t\t\t\t\t\t\t) from \"Operations\" o  where uo.\"Id\" = o.\"Order_id\"\n\t\t \t\t\t\t\t\t)\n\t\t \t\t\t\t)\n\t\t \t\t) from \"UserOrder\" uo  where u.\"Id\" = uo.\"User_ID\"\n\t\t \n\t\t \t) \n\t\t)\n\t)\n) from \"Users\" u;\n;";
var conn = new NpgsqlConnection(connectionString);
conn.Open();
#pragma warning disable CA2000
var cmd = new NpgsqlCommand(sql, conn);
#pragma warning restore CA2000

NpgsqlDataReader reader = cmd.ExecuteReader();

string? jsonString;
reader.Read();
jsonString = reader[0].ToString();

conn.Close();

if (jsonString != null)
{
    var users = new Users(jsonString);
    Console.WriteLine(users.Serial());
}

// using System.Net;
// using TestClient;
//
// #pragma warning disable IDE0059
// #pragma warning disable CA2000
// var client = new SocketClient(Dns.GetHostEntry("127.0.0.1").AddressList[0], 11235);
// #pragma warning restore CA2000
// #pragma warning restore IDE0059
// client.Call("ALL");
