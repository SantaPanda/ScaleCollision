using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using LitJson;

class httpClient : UseHttp
{
    private static Uri url = new Uri("http://123.207.86.90:8080/GameServer_war/HelloWorld");

    public static void postHttp(int id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:test");
        request.Headers.Add("t:"+id);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        //int byteReader=respStreamReader.Read()
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        string test = json["link"].ToString();
//        JSONObject json = new JSONObject(s);
//        string test = json.GetString("link");
        //Console.WriteLine(respStreamReader.ReadToEnd());
    }

    /// <summary>
    /// 添加胜利结果。
    /// </summary>
    /// <param name="userId">User identifier.</param>
    public void AddWin(int userId)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:addWin");
        request.Headers.Add("userId:" + userId);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        
    }


    /// <summary>
    /// 购买英雄.
    /// </summary>
    /// <returns>The hero.</returns>
    /// <param name="userId">User identifier.</param>
    /// <param name="consumptionType">Consumption type.</param>
    /// <param name="heroesID">Heroes I.</param>
    public int BuyHero(int userId, string consumptionType, int heroesID)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:buyHero");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("consumptionType:" + consumptionType);
        request.Headers.Add("heroesID:" + heroesID);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public int BuySkin(int userId, string consumptionType, int skinId)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:buySkin");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("consumptionType:" + consumptionType);
        request.Headers.Add("skinId:" + skinId);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public int ChangeName(int userId, string PlayerName)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:changeName");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("PlayerName:" + PlayerName);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public int ChangeSetting(int userId, int openMusic, int openSound)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:changeSetting");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("openMusic:" + openMusic);
        request.Headers.Add("openSound:" + openSound);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    

    public JsonData LoginIn(string userAccount, string userPWD)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:loginIn");
        request.Headers.Add("userAccount:" + userAccount);
        request.Headers.Add("userPWD:" + userPWD);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
//        JSONObject json = new JSONObject(s);
        return json;
    }

    public int Recharge(int userId, int money)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:recharge");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("money:" + money);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public int Register(string userAccount, string userPWD)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:register");
        request.Headers.Add("userAccount:" + userAccount);
        request.Headers.Add("userPWD:" + userPWD);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public int ChangeHead(int userId, int headPortrait)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:changeHead");
        request.Headers.Add("userId:" + userId);
        request.Headers.Add("headPortrait:" + headPortrait);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return Int32.Parse(json["result"].ToString());
//        JSONObject json = new JSONObject(s);
//        return json.GetInt("result");
    }

    public JsonData GetGameRecord(int userId)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:getGameRecord");
        request.Headers.Add("userId:" + userId);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
        return json;
//        JSONObject json = new JSONObject(s);
    }

    public int StartGame(int userId)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:start");
        request.Headers.Add("userId:" + userId);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        string s = respStreamReader.ReadToEnd();
        JsonData json = JsonMapper.ToObject(s);
//        JSONObject json = new JSONObject(s);
        //新建线程建立socket连接
        Thread t = new Thread(delegate () { startSocketServer(Int32.Parse(json["port"].ToString())); });
        t.Start();
        //返回获取的端口
        return Int32.Parse(json["port"].ToString());
//        return json.GetInt("port");
    }

    public void startSocketServer(int port)
    {
        socketLink.NewSocketLink(port);
    }

    public void Stop(int port)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ProtocolVersion = new Version(1, 1);
        request.Headers.Add("operation:stop");
        request.Headers.Add("ReturnPort:" + port);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream respStream = response.GetResponseStream();
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
    }
}

