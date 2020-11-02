using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace udpReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            // udpsender is reading the incoming data 
            UdpClient udpReciever = new UdpClient(9999);
            // IP address of single Host device  .............
            // what happened when many host devices send messages ( how you define IP addresses of each device) 
            // IP address should be a remote device
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
            Console.WriteLine("Reciever is Blocked");
            try
            {
                while(true)
                {
                    // Recieved bytes of data from remote device 
                    Byte[] recieveBytes = udpReciever.Receive(ref remoteIpEndPoint);
                    string recievedData = Encoding.ASCII.GetString(recieveBytes);
                    Console.WriteLine("Sender:" + recievedData.ToString());
                    Console.WriteLine("This message was sent from" 
                                       + remoteIpEndPoint.Address.ToString() + 
                                        "on their port number" +
                                         remoteIpEndPoint.Port.ToString());
                    // here we change the input values to capital form
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(recievedData.ToUpper());
                    // How UDPsender knows that The datagram coming from which remote device 
                    udpReciever.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);

                    Thread.Sleep(500);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
