using System;
using System.Net;
using System.Net.Sockets;

namespace WebServer
{
    public class Response
    {
        public void SendResponse(Socket clientSocket, string fileToDisplay)
        {
            Console.WriteLine("Sending response...\n");

            bool reuseSoceket = true;
            

            // check content length of the response body
            long contentLength = new System.IO.FileInfo(fileToDisplay).Length;

            // Create a response message
            string responseHeaders = "HTTP/1.1 200 OK\r\n" +
                                     "Content-Type: text/html\r\n" +
                                     $"Content-Length: {contentLength}\r\n" +
                                     "Connection: close\r\n" +
                                     "\r\n";


            // Convert the response message to a byte array
            byte[] responseHeaderBytes = System.Text.Encoding.UTF8.GetBytes(responseHeaders);

            // Send the response headers to the client followed by the file
            clientSocket.Send(responseHeaderBytes);
            clientSocket.SendFile(fileToDisplay);

            Console.WriteLine("[*] Response sent to client [*]\n");


            //Close the client socket but set it ready for reuse
            clientSocket.Disconnect(reuseSoceket);
        }        
    }
}