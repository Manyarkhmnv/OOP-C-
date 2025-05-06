using System.Net;
using Client;
using ServerController.Models;
using ServerModel;
using TestClient;

namespace ServerController;

public class RestController
{
    public SocketClient SocketClient { get; private set; } = new SocketClient(Dns.GetHostEntry("127.0.0.1").AddressList[0], 11235);
    private bool IsAuth { get; set; }

    public bool TryAuth(string login, string password)
    {
        var user = new User();
        var a = new API("AUTH", new List<string>() { login, password });
        string b = SocketClient.Call(a.Serial());
        User? u = user.Deserial(b);
        string? pin = string.Empty + u?.Pin;
        Console.WriteLine(u?.Error);
        if (password != null && u?.Fullname == login && pin == password)
        {
            IsAuth = true;
            Console.WriteLine("AUUUUTH");
        }

        return IsAuth;
    }

    public void ViewBalance(string orderNumber)
    {
        if (IsAuth)
        {
            var a = new API("ORDER", new List<string>() { orderNumber });
            var order = new Order();
            Console.WriteLine("SERIAL>>>>>" + a.Serial());
            string b = SocketClient.Call(a.Serial());
            Order? o = order.Deserial(b);
            Console.WriteLine(o?.Error);
            Console.WriteLine("Order:");
            Console.WriteLine(o?.Serial());
        }
    }

    public void ViewOperations(string orderNumber)
    {
        if (IsAuth)
        {
            var a = new API("OPERATIONS", new List<string>() { orderNumber });
            var order = new Order();
            Console.WriteLine("SERIAL>>>>>" + a.Serial());
            string b = SocketClient.Call(a.Serial());
            Order? o = order.Deserial(b);
            Console.WriteLine(o?.Error);
            Console.WriteLine("Order:");
            Console.WriteLine(o?.Serial());
        }
    }

    public void Withdraw(int amount, string orderNumber)
    {
        if (IsAuth)
        {
            string value = $"{amount}";
            var order = new Operation();
            var a = new API("WITHDRAW", new List<string>() { value, orderNumber });
            string message = SocketClient.Call(a.Serial());
            Operation? o = order.Deserial(message);
            Console.WriteLine(o?.Error);
            Console.WriteLine(message);
        }
    }

    public void Deposite(int amount, string orderNumber)
    {
        if (IsAuth)
        {
            string value = $"{amount}";
            var order = new Operation();
            var a = new API("DEPOSITE", new List<string>() { value, orderNumber, });
            string message = SocketClient.Call(a.Serial());
            Operation? o = order.Deserial(message);
            Console.WriteLine(o?.Error);
            Console.WriteLine(message);
        }
    }

    public void CreateOrder(int userId, string orderNumber)
    {
        if (IsAuth)
        {
            string id = $"{userId}";
            var a = new API("CREATE ORDER", new List<string>() { id, orderNumber, });
            string message = SocketClient.Call(a.Serial());
            Console.WriteLine(message);
        }
    }
}