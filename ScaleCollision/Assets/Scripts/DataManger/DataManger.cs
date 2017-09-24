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
            return 1;
        }
        else
        {
            return isSuccess;
        }
    }
}


