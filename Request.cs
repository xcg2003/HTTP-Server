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
            Console.WriteLine("Parsing request...");

            // Revice the data from the client and store it in the buffer
            int bytesReceived = clientSocket.Receive(buffer);

           // set up NetworkStream to recive and decode request


			//seprate the request line, headers, and message body
			
			
        }

		private void DisplayRequest(string requestLine, string requestHeaders, string requestBody)
		{
			Console.WriteLine("Test for now");
		}
    }


}
