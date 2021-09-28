using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestSocket
{
    class Program
    {
        static Socket ClientSocket;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String IP = "127.0.0.1";
            int port = 1111;

            IPAddress ip = IPAddress.Parse(IP);  //将IP地址字符串转换成IPAddress实例
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议
            IPEndPoint endPoint = new IPEndPoint(ip, port); // 用指定的ip和端口号初始化IPEndPoint实例
            ClientSocket.Connect(endPoint);  //与远程主机建立连接

            Msg msg = new Msg();
            msg.MsgId = "1";
            msg.Data = new List<Data>();
            msg.Data.Add(new Data { GigaInferno = "12", level = 12 });
            msg.Data.Add(new Data { GigaInferno = "13", level = 13 });
            msg.Data.Add(new Data { GigaInferno = "14", level = 14 });
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new DefaultContractResolver();
            var Msgs= JsonConvert.SerializeObject(msg, serializerSettings);
            Console.WriteLine("开始发送消息");
            byte[] message = Encoding.UTF8.GetBytes(Msgs);  //通信时实际发送的是字节数组，所以要将发送消息转换字节
            ClientSocket.Send(message);
            Console.WriteLine("发送消息为:" + Encoding.ASCII.GetString(message));
            byte[] receive = new byte[1024];
            int length = ClientSocket.Receive(receive);  // length 接收字节数组长度
            Console.WriteLine("接收消息为：" + Encoding.ASCII.GetString(receive));
            ClientSocket.Close();  //关闭连接
        }
    }
}
