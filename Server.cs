using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;


namespace WebServer
{
    class Server
    {
        //create socket
        private Socket? listener;

        //bind socket to port
        public Socket Start(int port, IPEndPoint localEndPoint)
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //bind the socket to a local endpoint
            listener.Bind(localEndPoint);

            return listener;
        }

        //listen for incoming connections
        public void Run(int port)
        {
            bool isRunning = true;
            //create local endpoint
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, port);

            Socket listnerSocket = Start(port, localEndPoint);
            listnerSocket.Listen();
            Console.WriteLine("Server is listening on port {0}...", port);


            while (isRunning)
            {
                //accept incoming connection
                Socket connectedSocket = listnerSocket.Accept();
                Console.WriteLine("Client connected.");

                //Handle request
                Request request = new Request();
                request.ParseRequest(connectedSocket);
                if (!connectedSocket.Connected)
                {
                    Console.WriteLine("Client disconnected.");
                    break;
                }

                //handle response
            }

            // shut off listener
            listnerSocket.Shutdown(SocketShutdown.Both);
            listnerSocket.Close();
            Console.WriteLine("Server is shutting down.");
        }   

        //parse incoming request

        //create response

        //send response
    }

}