using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestClient;

public class SocketClient : Socket
{
    private byte[] bytes = new byte[1024];
    private int bufferSize;
    private IPEndPoint ipEndPoint;
    private AddressFamily _addressFamily;
    public SocketClient(IPAddress address, int port)
        #pragma warning disable CA1062
        : base(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
        #pragma warning restore CA1062
    {
        bufferSize = 1024;
        bytes = new byte[bufferSize];
        ipEndPoint = new IPEndPoint(address, port);
        _addressFamily = address.AddressFamily;
    }

    public string Call(string message)
    {
        var sender = new Socket(_addressFamily, SocketType.Stream, ProtocolType.Tcp);
        sender.Connect(ipEndPoint);
        Send(sender, message);
        string answer = Receive(sender);

        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
        return answer;
    }

    private static string Bytes2String(byte[] bytes)
    {
        return Encoding.ASCII.GetString(bytes);
    }

    private static byte[] String2bytes(string str)
    {
        return Encoding.ASCII.GetBytes(str);
    }

    private static List<byte[]> Bytes2Chunks(byte[] byteData, long bufferSize)
    {
        var a = byteData.Select((value, index) => new { PairNum = Math.Floor(index / (double)bufferSize), value });
        var b = a.GroupBy(pair => pair.PairNum);
        IEnumerable<byte[]> c = b.Select(grp => grp.Select(g => g.value).ToArray());
        byte[][] d = c.ToArray();
        return d.ToList();
    }

    private static byte[] Chunks2bytes(List<byte[]> chunks)
    {
        byte[] result = new byte[chunks.Sum(a => a.Length)];
        using var stream = new MemoryStream(result);
        foreach (byte[] bytes in chunks)
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        return result;
    }

    private void Send(Socket handler, string message)
    {
        IList<byte[]> chunks = Bytes2Chunks(String2bytes(message), bufferSize);
        int sendCounts = chunks.Count;
        handler.Send(Encoding.UTF8.GetBytes($"{sendCounts}"));
        foreach (byte[] chunk in chunks)
        {
            handler.Send(chunk);
        }
    }

    private string Receive(Socket handler)
    {
        int bytesRec = handler.Receive(bytes);
        if (int.TryParse(Encoding.UTF8.GetString(bytes, 0, bytesRec), out int receiveCount))
        {
            Console.WriteLine(Bytes2String(bytes));
        }

        var chunks = new List<byte[]>();
        for (int i = 0; i < receiveCount; i++)
        {
            handler.Receive(bytes);

            // Console.WriteLine("CLIENT>>>" + $"{Bytes2String(bytes)}");
            chunks.Add(bytes);
            bytes = new byte[1024];
        }

        // Console.WriteLine("RECEIVED CHUNKS>>>" + $"{Bytes2String(Chunks2bytes(chunks))}");
        return Bytes2String(Chunks2bytes(chunks));
    }
}