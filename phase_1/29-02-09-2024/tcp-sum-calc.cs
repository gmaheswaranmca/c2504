//Sum calculator
//1. reading two numbers from client and find sum in server
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
        //Read firstNum from network
        bufferReadSize = stream.Read(bufferRead, 0, bufferRead.Length);
        double firstNum = Double.Parse(Encoding.ASCII.GetString(bufferRead, 0, bufferReadSize));
        Console.WriteLine($"first number: {firstNum}");
        //Read secondNum from network
        bufferReadSize = stream.Read(bufferRead, 0, bufferRead.Length);
        double secondNum = Double.Parse(Encoding.ASCII.GetString(bufferRead, 0, bufferReadSize));
        Console.WriteLine($"second number: {secondNum}");
        //Write sum into network
        double sum = firstNum + secondNum;
        Console.WriteLine($"sum: {sum}");
        bufferWrite = Encoding.ASCII.GetBytes(sum.ToString());
        stream.Write(bufferWrite, 0, bufferWrite.Length);
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
        //Write firstNum into network 
        Console.Write("First Number:");
        double firstNum = double.Parse(Console.ReadLine());
        bufferWrite = Encoding.ASCII.GetBytes(firstNum.ToString());
        stream.Write(bufferWrite,0, bufferWrite.Length);
        //Write secondNum into network 
        Console.Write("Second Number:");
        double secondNum = double.Parse(Console.ReadLine());
        bufferWrite = Encoding.ASCII.GetBytes(secondNum.ToString());
        stream.Write(bufferWrite, 0, bufferWrite.Length);
        //Read sum from network 
        bufferReadSize = stream.Read(bufferRead, 0, bufferRead.Length);
        double sum = Double.Parse( Encoding.ASCII.GetString(bufferRead,0, bufferReadSize) );
        Console.WriteLine($"sum: {sum}");
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
