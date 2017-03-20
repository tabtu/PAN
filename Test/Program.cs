﻿using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;

namespace Test
{
    class SocketClient
    {

        public static Socket clientSocket;

        public static string SocketConnect(string HostIP, int HostPort)
        {
            int time = 0;
            int RETRY_TIME = 3;

            string a = "";

            IPAddress ipAddress = IPAddress.Parse(HostIP);  //Transform the string into IPAddress

            clientSocket = new Socket(  //Initialize the socket for client using TCP
              AddressFamily.InterNetwork,
              SocketType.Stream,
              ProtocolType.Tcp);

            do
            {
                try
                {
                    clientSocket.Connect(ipAddress, HostPort);  //Connect to Server
                    a = "Client is connected.\n";
                    break;
                }
                catch (Exception e)
                {
                    time++;
                    if (time < RETRY_TIME)  //If timeout, try to reconncet
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    else a = "Time out.\n";
                }
            } while (time < RETRY_TIME);
            return a;
        }

        /*public static void reconnect(string HostIP, int HostPort)
        {
            if(clientSocket != null)
            {
                if(clientSocket.Connected == false)
                {
                    IPAddress ipAddress = IPAddress.Parse(HostIP);
                    clientSocket.Connect(ipAddress, HostPort);
                }
            }
        }*/

        public static string send(string input) //send data to server
        {
            string a = "";

            if (clientSocket.Connected == true)
            {
                byte[] sendBuffer = Encoding.ASCII.GetBytes(input);
                clientSocket.Send(sendBuffer);
                a = "Sent data.\n";
            }
            else a = "Operation failed.\n";
            return a;
        }
        public static string disconnect()   //disconnection
        {
            string a = "";

            if (clientSocket.Connected == true)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                a = "Disconnected.";
            }
            else a = "No connection existed.";
            return a;
        }




        public static Socket cSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] result = new byte[1024];

        public static void Init(string addr, int port)
        {
            //设定服务器IP地址
            IPAddress ip = IPAddress.Parse(addr);
            try
            {
                cSocket.Connect(new IPEndPoint(ip, port)); //配置服务器IP与端口
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }

            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();

        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="clientSocket"></param>
        private static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    int receiveNumber = cSocket.Receive(result);
                    string strContent = Encoding.ASCII.GetString(result, 0, receiveNumber);
                    Console.WriteLine("接收服务端{0}消息{1}", cSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result, 0, receiveNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cSocket.Shutdown(SocketShutdown.Both);
                    cSocket.Close();
                    break;
                }
            }
        }
        public static void SendMessage(string message)
        {
            string sendMessage = message;
            cSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("int: " + sizeof(int));
            Console.WriteLine("long: " + sizeof(long));
            Console.WriteLine("double: " + sizeof(double));

            IList<SerMod> test = new List<SerMod>();
            SerMod t1 = new SerMod("1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;");
            SerMod t2 = new SerMod("2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;");
            SerMod t3 = new SerMod("3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;");
            test.Add(t1);
            test.Add(t2);
            test.Add(t3);

            string tmp = "";
            foreach(SerMod ele in test) { tmp += (ele.ToStringExt() + "/"); }
            Console.WriteLine(tmp);
            Console.WriteLine("Model: " + Marshal.SizeOf(t1));




            string[] smlist = tmp.Split('/');
            IList<SerMod> mylist = new List<SerMod>();
            for (int i = 0; i < smlist.Length - 1; i++)
            {
                SerMod ss = new SerMod(smlist[i]);
                mylist.Add(ss);
            }

            Console.WriteLine(mylist.Count);

            //SocketClient.Init("222.222.222.3", 18888);
        }
    }
}