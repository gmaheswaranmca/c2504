 //1. calc sum at server of two numbers from client
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
         //Read firstNum from client
         bufferRead = server.Receive(ref clientEndPoint);
         double firstNum = double.Parse(Encoding.ASCII.GetString(bufferRead));
         Console.WriteLine($"firstNum: {firstNum}");
         //Read secondNum from client
         bufferRead = server.Receive(ref clientEndPoint);
         double secondNum = double.Parse(Encoding.ASCII.GetString(bufferRead));
         Console.WriteLine($"secondNum: {secondNum}");
         //Write sum into client
         double sum = firstNum + secondNum;
         Console.WriteLine($"sum: {sum}");
         bufferWrite = Encoding.ASCII.GetBytes(sum.ToString());
         server.Send(bufferWrite, bufferWrite.Length, clientEndPoint);

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


         //Write firstNum into server
         Console.Write("First Number:"); double firstNum = double.Parse( Console.ReadLine());
         bufferWrite = Encoding.ASCII.GetBytes(firstNum.ToString());
         client.Send(bufferWrite, bufferWrite.Length);
         //Write secondNum into server
         Console.Write("Second Number:"); double secondNum = double.Parse(Console.ReadLine());
         bufferWrite = Encoding.ASCII.GetBytes(secondNum.ToString());
         client.Send(bufferWrite, bufferWrite.Length);
         //Read sum from server
         bufferRead = client.Receive(ref remoteEndPoint);
         double sum = double.Parse(Encoding.ASCII.GetString(bufferRead));           
         Console.WriteLine($"sum: {sum}");

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
