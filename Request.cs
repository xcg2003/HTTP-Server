using System;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;

namespace WebServer
{
    public class Request
    {
        public void ParseRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            Console.WriteLine("Parsing request...\n");

            // Revice the data from the client and store it in the buffer
            int bytesReceived = clientSocket.Receive(buffer);

            // Convert the byte array to a string
            string requestString = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

            //seprate the request line, headers, and message body
            string[] requestParts = requestString.Split("\r\n\r\n");
            string[] lines = requestParts[0].Split("\r\n");
            string requestLine = lines[0];
            string requestHeaders = string.Join("\r\n", lines, 1, lines.Length - 1);
            string requestBody = requestParts[1];

            // Display the request line, headers, and body
            Console.WriteLine("Request Line: {0}\n", requestLine);
            Console.WriteLine("Request Headers:");
            Console.WriteLine(requestHeaders);
            Console.WriteLine("\nRequest Body: {0}\n", requestBody);
        }   
    }
}
