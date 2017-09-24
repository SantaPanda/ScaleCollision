using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


class socketLink
{
    static Socket socket = null;
    static bool IfSend = false;
    static bool InSelect = false;
    static byte[] info;

    internal static void NewSocketLink(int port)
    {
        
        MemoryStream memStream = null;
        string returnMsg = string.Empty;
        //与服务器建立连接
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //设定服务器IP地址  
        IPAddress ip = IPAddress.Parse("123.207.86.90");
        IPEndPoint endPt = new IPEndPoint(ip, 4331);
        socket.Connect(endPt);
        //接收数据
        byte[] buffer = new byte[1024];
        int recCount = 0;
        String getInfo = null;
        memStream = new MemoryStream();
        //接收返回的字节流
        while (true)
        {
            Thread.Sleep(50);
            recCount = socket.Receive(buffer);
            Console.WriteLine("字数" + recCount);
            Console.WriteLine(System.Text.Encoding.Default.GetString(buffer.Skip(0).Take(recCount).ToArray()));
            getInfo = System.Text.Encoding.Default.GetString(buffer.Skip(0).Take(recCount).ToArray());
            //处理返回数据
            if ("ok".Equals(getInfo)){//进入英雄选择界面
                InSelect = true;
            }
            if (InSelect)
            {
                if (getInfo != null)
                {
                    //getInfo-'0' 为选择英雄的ID，获取设置对方选择的英雄

                    InSelect = false;
                }
            }
            else if ("1".Equals(getInfo))//使用技能
            {

            }
            else if ("2".Equals(getInfo))//跳跃
            {

            }
            //发送数据
            if (IfSend)
            {
                socket.Send(info, info.Length, SocketFlags.None);
                IfSend = false;
            }
            //socket.Send(Encoding.ASCII.GetBytes("a"));
            Array.Clear(buffer, 0, buffer.Length);
        }
    }
    static void send(byte[] infos)//发送数据
    {
        IfSend = true;
        info = infos;
    }

    static void setHero(int HeroId)//选择英雄
    {
        IfSend = true;
        byte[] sendHero = new byte[2];
        sendHero[0] = (byte)'!';
        sendHero[1] = (byte)((byte)'0' + HeroId);
        info = sendHero;
    }
}

