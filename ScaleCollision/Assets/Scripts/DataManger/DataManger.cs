using System;
using EnumDataDef;
using LitJson;

public class DataManger
{
    private static DataManger mInstance;
    public static DataManger Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new DataManger();
            }
            return mInstance;
        }
    } 
    
    public DataManger()
    {
    }

    //登录时调用，账号、密码正确返回1，账号正确密码错误返回2，否则返回0；
    //玩家数据PlayerData.{userId, PlayerName, headPortrait, Dictionary<heroesId, isHas>, Dictionary<skinId, isHas>, golds, cashCoupons , openMusic, openSound}
    public int AnalyzeLoginJson(JsonData json)
    {
        int isSuccess = Int32.Parse(json["result"].ToString());
        if (isSuccess == 1)
        {
            JsonData playerData = json["PlayerData"];
            DataCenter.Instance.playerData.isBgMusicOpen = bool.Parse(playerData["openMusic"].ToString());
            DataCenter.Instance.playerData.isSoundOpen = bool.Parse(playerData["openSound"].ToString());
            DataCenter.Instance.playerData.userId = Int32.Parse(playerData["userID"].ToString());
            DataCenter.Instance.playerData.name = playerData["PlayerName"].ToString();
            DataCenter.Instance.playerData.golds = Int32.Parse(playerData["golds"].ToString());
            DataCenter.Instance.playerData.cash = Int32.Parse(playerData["cashCoupons"].ToString());
            DataCenter.Instance.playerData.PortraitId = Int32.Parse(playerData["headPortrait"].ToString());

            JsonData heroProcess = playerData["Dictionary<heroesId, isHas>"];
            JsonData skinProcess = playerData["Dictionary<skinId, isHas>"];

            foreach (var Dhero in HeroData.dataMap)
            {
                DataCenter.Instance.playerData.heroes.Add(Dhero.Value.id, bool.Parse(heroProcess[Dhero.Value.id.ToString()].ToString()));
                DataCenter.Instance.playerData.skin.Add(Dhero.Value.id, bool.Parse(skinProcess[Dhero.Value.id.ToString()].ToString()));
            }

            return 1;
        }
        else
        {
            return isSuccess;
        }
    }

    public int AnalyzeLogJson(JsonData json)
    {
        int isSuccess = Int32.Parse(json["result"].ToString());
        if (isSuccess == 1)
        {
            JsonData gameRecord = json["GameRecord"];
            DataCenter.Instance.playerData.gameCount = Int32.Parse(gameRecord["totalCount"].ToString());
            DataCenter.Instance.playerData.winCount = Int32.Parse(gameRecord["winCount"].ToString());
            DataCenter.Instance.playerData.loseCount = Int32.Parse(gameRecord["loseCount"].ToString());

            return 1;
        }
        else
        {
            return 0;
        }
    }
}


