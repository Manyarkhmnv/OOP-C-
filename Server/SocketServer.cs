using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestServer;

public class SocketServer : Socket
{
    private byte[] bytes = new byte[1024];
    private int bufferSize;

    public SocketServer(IPAddress address, int port)
        #pragma warning disable CA1062
        : base(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
        #pragma warning restore CA1062
    {
        bufferSize = 1024;
        bytes = new byte[bufferSize];
        Bind(new IPEndPoint(address, port));
        Listen(10);

    // while (true)
    //     {
    //         Console.WriteLine("Ожидаем соединение через порт 11000");
    //         Socket handler = Accept();
    //
    //         // Мы дождались клиента, пытающегося с нами соединиться
    //         string s = Receive(handler);
    //         Console.Write("Полученный текст: " + s + "\n\n");
    //         Send(handler, s);
    //         Close(handler);
    //     }
    }

    private static void Close(Socket handler)
    {
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }

    private static string Bytes2String(byte[] bytes)
    {
        return Encoding.ASCII.GetString(bytes);
    }

    private static byte[] String2Bytes(string str)
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

    private static byte[] Chunks2Bytes(List<byte[]> chunks)
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
        List<byte[]> chunks = Bytes2Chunks(String2Bytes(message), bufferSize);
        int sendCounts = chunks.Count;
        if (handler == null) return;
        handler.Send(Encoding.UTF8.GetBytes($"{sendCounts}"));
        foreach (byte[] chunk in chunks)
        {
            Console.WriteLine($"SERVER>>>{Bytes2String(chunk)}");
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
            chunks.Add(bytes);
            Console.WriteLine(Bytes2String(bytes));
        }

        return Bytes2String(Chunks2Bytes(chunks));
    }
}