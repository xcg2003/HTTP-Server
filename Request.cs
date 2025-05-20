using System;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;

namespace WebServer
{
    public class Request
    {
        public void ParseRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            Console.WriteLine("Parsing request...");

            // Revice the data from the client and store it in the buffer
            int bytesReceived = clientSocket.Receive(buffer);

            // Convert the byte array to a string
            //String requestString = System.Text.Encoding.UTF8.GetDecoder();
        }
    }
}