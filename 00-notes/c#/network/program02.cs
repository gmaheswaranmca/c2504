//1. sending greetings of 'person name, which gets from client'
public class SimpleServer
{
    public void service(string ipAddr = "127.0.0.1", int port = 13000)
    {
        //1
        UdpClient server = new UdpClient(port);
        Console.WriteLine($"[DEBUG]1.Server is created...");//DEBUG

        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, port);
        
        string personName = null;
        //2
        Console.WriteLine($"[DEBUG]2.Server is listening on port {port}...");//DEBUG
        Console.WriteLine($"[DEBUG]2.communication started...");//DEBUG

        //2.1Receive personName
        byte[] bytes = server.Receive(ref clientEndPoint);
        personName = Encoding.ASCII.GetString(bytes).Trim();
        Console.WriteLine($"[DEBUG]2-1.personName received...");//DEBUG
        Console.WriteLine($"person name: {personName}");//INFO
        //2.2Send greetings
        string greetName = $"hello {personName}!";
        Console.WriteLine($"greetings: {greetName}");//INFO

        byte[] msg = Encoding.ASCII.GetBytes(greetName);
        server.Send(msg, msg.Length, clientEndPoint);
        Console.WriteLine("[DEBUG]2-2.greetings sent.");//DEBUG

        //3
        server.Close();
        Console.WriteLine($"[DEBUG]3.Server is released...");//DEBUG
    }
}
public class SimpleClient
{
    public void service(string serverAddress = "127.0.0.1", int port = 13000)
    {
        //1
        UdpClient client = new UdpClient();
        Console.WriteLine($"[DEBUG]1.Client is created...");//DEBUG
        //2
        client.Connect(serverAddress, port); //connection less networking
        Console.WriteLine($"[DEBUG]2.Client is connected to the server...");//DEBUG
        Console.WriteLine($"[DEBUG]3.communication started...");//DEBUG


        //3.1 Send personName
        Console.Write("Person Name:");
        string message = Console.ReadLine();

        byte[] data = Encoding.ASCII.GetBytes(message);
        client.Send(data, data.Length);
        Console.WriteLine($"[DEBUG]3.1 personName sent...");//DEBUG


        //3.2 Receive greetings
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
        byte[] responseData = client.Receive(ref remoteEndPoint);
        Console.WriteLine($"[DEBUG]3.2 greetings received...");//DEBUG
        string greetName = Encoding.ASCII.GetString(responseData);
        Console.WriteLine($"greetings: {greetName}");

        //4 cleaning up
        client.Close();
        Console.WriteLine($"[DEBUG]4.Cleaning up...");//DEBUG
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