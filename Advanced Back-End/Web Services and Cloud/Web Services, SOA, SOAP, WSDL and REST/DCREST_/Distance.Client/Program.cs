using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

class Program
{
    static void Main()
    {
        WebClient client = new WebClient();
        string address = "http://localhost:50560/CalculateDistance?startX=10&endX=10&startY=15&endY=15";
        var query = client.UploadString(address, "GET");

        Console.WriteLine(query);
    }
}
