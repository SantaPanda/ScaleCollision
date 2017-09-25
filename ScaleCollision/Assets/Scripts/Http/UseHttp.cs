using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


interface UseHttp
{
    JsonData LoginIn(String userAccount, String userPWD);//登录时调用，账号、密码正确返回1，账号正确密码错误返回2，否则返回0；
    int Register(String userAccount, String userPWD);//注册时调用，创建成功返回1，否则返回0；
    //JSONObject GetInformation(String account);//玩家数据PlayerData.{userId, PlayerName, headPortrait, Dictionary<heroesId, isHas>, Dictionary<skinId, isHas>, golds, cashCoupons , openMusic, openSound}
    int ChangeName(int userId, String PlayerName);//正确返回1，错误返回0
    int ChangeSetting(int userId, int openMusic, int openSound);//游戏设置，成功返回1，否则返回0
    int Recharge(int userId, int money);//充值，成功返回1，否则返回0
    int BuyHero(int userId, String consumptionType, int heroesID);//购买英雄，成功返回1，否则返回0
    int BuySkin(int userId, String consumptionType, int skinId);//购买皮肤，成功返回1，否则返回0
    int ChangeHead(int userId, int headPortrait); //修改头像，成功返回1，否则返回0.
    JsonData GetGameRecord(int userId); //正确返回1，错误返回0,GameRecord{totalCount, winCount, loseCount};
    void AddWin(int userId);//为该ID增加胜利场数

    //int StartGame(int userId);//返回端口，O为无空闲端口；要记住该端口，在结束游戏时要归还
    //void Stop(int port);//结束游戏，归还端口
}

