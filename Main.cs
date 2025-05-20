using System;
using System.Security.Cryptography.X509Certificates;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Run(8888);
            // Your code here
        }
    }
}