   //1. text chat between client[girish] and server[yahkoop], once the msg "end" -> stop the chat 
   //  client initiates the chat 
   public class SimpleServer
   {
       public void service(string ipAddr = "127.0.0.1", int port = 13000)
       {
           byte[] bufferWrite;
           byte[] bufferRead;
           //1
           UdpClient server = new UdpClient(port); 
           IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, port);
           //2
           string text = "end";
           do
           {
               //Read from yahkoop
               bufferRead = server.Receive(ref clientEndPoint);
               text = Encoding.ASCII.GetString(bufferRead);
               Console.WriteLine($"girish: {text}");
               if(text.Equals("end"))
               {
                   break;
               }
               //Write into yahkoop
               Console.Write("yahkoop:");
               text = Console.ReadLine();
               bufferWrite = Encoding.ASCII.GetBytes(text);
               server.Send(bufferWrite, bufferWrite.Length, clientEndPoint);
           } while (!text.Equals("end"));




           //3
           server.Close();
          
       }
   }
   public class SimpleClient
   {
       public void service(string serverAddress = "127.0.0.1", int port = 13000)
       {
           byte[] bufferWrite;
           byte[] bufferRead;
           //1
           UdpClient client = new UdpClient();

           //2
           IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
           client.Connect(serverAddress, port); //connection less networking


           string text = "end";
           do
           {
               //Write into girish
               Console.Write("girish:");
               text = Console.ReadLine();
               bufferWrite = Encoding.ASCII.GetBytes(text);
               client.Send(bufferWrite, bufferWrite.Length);
               if (text.Equals("end"))
               {
                   break;
               }
               //Read from girish
               bufferRead = client.Receive(ref remoteEndPoint);
               text = Encoding.ASCII.GetString(bufferRead);
               Console.WriteLine($"yahkoop: {text}");
           } while (!text.Equals("end"));

           //4 cleaning up
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