using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Sockets;

namespace ServiceSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var config = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("hosting.json", optional: true)
            //     .Build();

            string currentIP = GetCurrentIP2();
            Console.WriteLine("CurrentIP: " + currentIP);
            string url = @"http://" + currentIP + ":5000";


            var host = new WebHostBuilder()
                //.UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseUrls(url)
                .UseStartup<Startup>()
                .Build();


            host.Run();
        }

        private static string GetCurrentIP()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);

            string ip = ipadrlist.Where(item => item.AddressFamily
            == System.Net.Sockets.AddressFamily.InterNetwork).LastOrDefault().ToString();

            return ip;
        }

        private static string GetCurrentIP2()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            socket.Connect("8.8.8.8", 65530);
            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            string localIP = endPoint.Address.ToString();
            return localIP;
        }

    }
}
