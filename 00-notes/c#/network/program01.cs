//TCP Socket Programming - Client / Server 
public class SimpleServer
{
    public void service(string ipAddr = "127.0.0.1", int port = 13000)
    {
        byte[] bytes = new byte[1024];// Buffer 
        string personName = null;

        //1 - create server object 
        TcpListener server = new TcpListener(IPAddress.Parse(ipAddr), port);
        Console.WriteLine($"[DEBUG]1.Server is created...");//DEBUG

        //2-start server
        server.Start();
        Console.WriteLine($"[DEBUG]2.Server is started...");//DEBUG

        //3.Listening to client 
        Console.WriteLine($"[DEBUG]3.Server is listening on port {port}...");//DEBUG
        TcpClient client = server.AcceptTcpClient(); //Blocked
        Console.WriteLine("Connected!");//DEBUG

        //4-communication between client and server
        NetworkStream stream = client.GetStream();
        Console.WriteLine($"[DEBUG]4.communication is started...");//DEBUG

        //4-i Receive data
        int i = stream.Read(bytes, 0, bytes.Length);
        personName = Encoding.ASCII.GetString(bytes, 0, i).Trim();
        Console.WriteLine($"[DEBUG]4.1 personName received...");//DEBUG
        Console.WriteLine($"person name: {personName}");//INFO



        // Send back a response
        string greetName = $"Hello {personName}";
        byte[] msg = Encoding.ASCII.GetBytes(greetName);
        //4-ii Send data
        stream.Write(msg, 0, msg.Length);
        Console.WriteLine($"[DEBUG]4.2 greetings sent...");//DEBUG
        Console.WriteLine($"greetings:{greetName}");//INFO

        //5-Release client
        client.Close();
        Console.WriteLine($"[DEBUG]5 client Released.");//DEBUG
        //6-Shutdown Server
        server.Stop();
        Console.WriteLine($"[DEBUG]6 server Shutdown.");//DEBUG
    }
}
public class SimpleClient
{
    public void service(string serverAddress = "127.0.0.1", int port = 13000)
    {
        byte[] responseBytes = new byte[1024];
        //1 - create client object 
        TcpClient client = new TcpClient(serverAddress, port);
        Console.WriteLine($"[DEBUG]1.Cleint is created...Press Any key"); Console.ReadKey();//DEBUG

        //2-communication between client and server
        NetworkStream stream = client.GetStream();
        Console.WriteLine($"[DEBUG]2.communication is started...Press Any key"); Console.ReadKey();//DEBUG

        Console.Write("Person Name:");//INFO
        string personName = Console.ReadLine();

        byte[] data = Encoding.ASCII.GetBytes(personName);
        //2-i Send data
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"[DEBUG]2-i.personName sent...");//DEBUG



        //2-ii Receive data
        int bytes = stream.Read(responseBytes, 0, responseBytes.Length);
        Console.WriteLine($"[DEBUG]2-ii.greetings received...");//DEBUG
        string greetName = Encoding.ASCII.GetString(responseBytes, 0, bytes);
        Console.WriteLine($"greetings: {greetName}");//INFO
        //3 Cleaning up client and its socket
        stream.Close();
        client.Close();
        Console.WriteLine($"[DEBUG]3.client cleaned up.");//DEBUG

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