using System.Net;
using System.Net.Sockets;

// using System.Net.Sockets;
// using System.Runtime.InteropServices.Marshalling;
using Npgsql;
using TestServer;

namespace ServerModel;

// singleton
public class Dao
{
    private const string ConnectionString = "Server=localhost;Port=5432;User Id=Masha;Password=123;Database=Lab5";
    private static Dao? instance;
    private Dictionary<string, string> _sqlCommands = new()
    {
        {
            "ALL",
            "select json_build_object(\n\t'Users', json_agg(\n\t\tjson_build_object('UserFullname', u.\"Fullname\", 'UserId', u.\"Id\", 'UserPin', u.\"Pin\",\n\t\t\t'UserOrders',  ( \n\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t'OrderId', uo.\"Id\", 'OrderBalance', uo.\"Balance\",\n\t\t \t\t\t\t\t\t'Operations', (\n\t\t \t\t\t\t\t\t\tselect json_agg(\n\t\t \t\t\t\t\t\t\t\tjson_build_object(\n\t\t \t\t\t\t\t\t\t\t\t'OperationId', o.\"Id\",\n\t\t \t\t\t\t\t\t\t\t\t'OperationFullname', o.\"Operation_name\",\n\t\t \t\t\t\t\t\t\t\t\t'OperationAmount', o.\"Amount\"\n\t\t \t\t\t\t\t\t\t\t)\n\t\t \t\t\t\t\t\t\t) from \"Operations\" o  where uo.\"Id\" = o.\"Order_id\"\n\t\t \t\t\t\t\t\t)\n\t\t \t\t\t\t)\n\t\t \t\t) from \"UserOrder\" uo  where u.\"Id\" = uo.\"User_ID\"\n\t\t \n\t\t \t) \n\t\t)\n\t)\n) from \"Users\" u;"
        },
        {
            // view balance +
            "ORDER",
            "select view_balance('{0}');"
        },
        {
            // view operations +
            "OPERATIONS",
            "select view_operations('{0}');"
        },
        {
            // add +
            "DEPOSITE",
            "select deposite({0}, '{1}')"
        },
        {
            "WITHDRAW",
            "select withdraw({0}, '{1}');"
        },
        {
            // auth +
            "AUTH",
            "select auth('{0}', '{1}');"
        },
        {
            "CREATE ORDER",
            "select addorder({0}, '{1}')"
        },
    };

    private Dao()
    {
    }

    public static Dao Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dao();
            }

            return instance;
        }
    }

    private NpgsqlConnection Conn { get; set; } = new NpgsqlConnection(ConnectionString);
    private SocketServer SocketServer { get; set; } = new SocketServer(Dns.GetHostEntry("127.0.0.1").AddressList[0], 11235);

    public void ToHellAndBack()
    {
        Socket handler = SocketServer.Wait();

        string s = SocketServer.Request(handler);
        var main_api = new API();
        API? api = main_api.Deserial(s);
        Console.WriteLine($"api >>>>>> {s}");
        string query = string.Empty;
#pragma warning disable CA1305
        if (api?.Name != null) query = string.Format(_sqlCommands[api.Name], api.Args.ToArray());
#pragma warning restore CA1305

        Console.WriteLine($"QUERY>>>> {query}");
        string? message = MakeQuery(query);
        Console.WriteLine($"message>>>> {message}");

        // Console.WriteLine($"NEWS>>>> {message}");
        if (message != null) SocketServer.Send(handler, message);

        if (handler != null)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }

    // boolean type needed
    public void ConnectToPG()
    {
        Conn.Open();
    }

    public string? MakeQuery(string? query)
    {
#pragma warning disable CA2007
        // read about open close connection to db pos/neg
        if (query != null)
        {
            Console.WriteLine($"QUERY>>>>>>>>>>>>>>>>>>>>>>>> {query}");
        }

        Conn.Open();
        if (_sqlCommands != null)
        {
            if (query != null)
            {
                if (Conn != null)
                {
#pragma warning disable CA2000
#pragma warning disable CA2100
                    var cmd = new NpgsqlCommand(query, Conn);
#pragma warning restore CA2100
#pragma warning restore CA2000
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string? result = reader[0].ToString();
                        Conn.Close();
                        return result;
                    }

                    return "{Error: true}";
                }
            }
        }

        return "{Error: true}";
    }
}