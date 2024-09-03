
using ProgramingFundamentalsProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace ProgramingFundamentalsProject
{
    //1. text chat between client[girish] and server[yahkoop], once the msg "end" -> stop the chat 
    //  client initiates the chat 
    
    public class SimpleServer
    {
        public void service(string ipAddr = "127.0.0.1", int port = 13000)
        {
            byte[] bufferWrite;
            byte[] bufferRead = new byte[1024];
            int bufferReadSize = 0;
            //1
            TcpListener server = new TcpListener(IPAddress.Parse(ipAddr), port);
            //2
            server.Start();
            //3
            Console.WriteLine($"[DEBUG]3.Server is listening on port {port}...");//DEBUG
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!");//DEBUG
                                            //4
            NetworkStream stream = client.GetStream();

            string text = "end";
            do
            {
                //girish
                bufferReadSize = stream.Read(bufferRead, 0, bufferRead.Length);
                text = Encoding.ASCII.GetString(bufferRead, 0, bufferReadSize);
                Console.WriteLine($"girish: {text}");
                if (text.Equals("end")) { break;  }
                //yahoop
                Console.Write($"yahkoop:"); text = Console.ReadLine();
                bufferWrite = Encoding.ASCII.GetBytes(text);
                stream.Write(bufferWrite, 0, bufferWrite.Length);
            } while (!text.Equals("end"));
           
            //5
            client.Close();
            //6
            server.Stop();
        }
    }
    public class SimpleClient
    {
        public void service(string serverAddress = "127.0.0.1", int port = 13000)
        {
            byte[] bufferWrite;
            byte[] bufferRead = new byte[1024];
            int bufferReadSize = 0;
            //1
            TcpClient client = new TcpClient(serverAddress, port);
            //2
            NetworkStream stream = client.GetStream();
            string text = "end";
            do
            {
                //girish
                Console.Write($"girish:"); text = Console.ReadLine();
                bufferWrite = Encoding.ASCII.GetBytes(text);
                stream.Write(bufferWrite, 0, bufferWrite.Length);
                if (text.Equals("end")) { break; }
                //yahoop
                bufferReadSize = stream.Read(bufferRead, 0, bufferRead.Length);
                text = Encoding.ASCII.GetString(bufferRead, 0, bufferReadSize);
                Console.WriteLine($"yahoop: {text}");
            } while (!text.Equals("end"));
            //3
            stream.Close();
            client.Close();
        }
    }

    internal class Programs
    {

        static void Main()
        {
            Console.Write("Option[1-Run Server, 2-Run Client]:");
            int option = int.Parse(Console.ReadLine());
            int port = 13000;//change it 
            string serverAddress = "127.0.0.1";
            switch (option)
            {
                case 1:
                    Console.WriteLine("Server Service to get started...");
                    SimpleServer server = new SimpleServer();
                    server.service(port: port);
                    break;
                case 2:
                    Console.WriteLine("Client Service to get started...");
                    SimpleClient client = new SimpleClient();
                    client.service(serverAddress: serverAddress, port: port);
                    break;
            }
            Console.WriteLine("\nPress Enter to exit...");
            Console.Read();
        }


    }



}



