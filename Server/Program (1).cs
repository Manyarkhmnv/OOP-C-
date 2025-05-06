using System.Net;
using TestServer;

#pragma warning disable CA2000
// ReSharper disable once UnusedVariable
#pragma warning disable IDE0059
var s = new SocketServer(Dns.GetHostEntry("127.0.0.1").AddressList[0], 11000);
#pragma warning restore IDE0059
#pragma warning restore CA2000
