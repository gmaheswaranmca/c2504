 public class SimpleServer
 {
     public void service(int port = 13000)
     {
         UdpClient server = new UdpClient(port);

         IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, port);
         string personName = null;
         
         Console.WriteLine($"Server is listening on port {port}...");//DEBUG
         // loop
         //while (true)
         //{
             byte[] bytes = server.Receive(ref clientEndPoint);
             personName = Encoding.ASCII.GetString(bytes).Trim();

             

             Console.WriteLine($"person name: {personName}");//INFO


         //}
         string greetName = $"hello {personName}!";
         Console.WriteLine($"greetings: {greetName}");//INFO

         byte[] msg = Encoding.ASCII.GetBytes(greetName);
         server.Send(msg, msg.Length, clientEndPoint);
         Console.WriteLine("greetings sent.");//DEBUG

         server.Close();
     }
 }
 public class SimpleClient
 {
     public void service(string server = "127.0.0.1", int port = 13000)
     {
         
         UdpClient client = new UdpClient();
         client.Connect(server, port);



         //while (true)
         //{
             Console.Write("Person Name:");
             string message = Console.ReadLine();

             byte[] data = Encoding.ASCII.GetBytes(message);
             client.Send(data, data.Length);
             Console.WriteLine("person name sent.");//DEBUG

         //}

         // Receive the response from the server
         IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
         byte[] responseData = client.Receive(ref remoteEndPoint);
         string greetName = Encoding.ASCII.GetString(responseData);
         Console.WriteLine($"greetings: {greetName}");

         Console.WriteLine("greetings received.");//DEBUG
         client.Close();

     }
 }
 
 internal class Programs
 {

     static void Main()
     {
         Console.Write("Option[1-Run Server, 2-Run Client]:");
         int option = int.Parse(Console.ReadLine());
         switch(option)
         {
             case 1:
                 Console.WriteLine("Server Service to get started..."); 
                 SimpleServer server = new SimpleServer();
                 server.service();
                 break;
             case 2:
                 Console.WriteLine("Client Service to get started...");
                 SimpleClient client = new SimpleClient();
                 client.service();
                 break;
         }
         Console.WriteLine("\nPress Enter to exit...");
         Console.Read();
     }
     

 }