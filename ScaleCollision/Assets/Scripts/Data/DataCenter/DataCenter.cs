using System;


public class DataCenter
{
    private static DataCenter mInstance;

    public static DataCenter Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new DataCenter();
            }
            return mInstance;
        }   
    }
  
    private PlayerData mPlayerData;
    public PlayerData playerData
    { 
        get
        {
            if (mPlayerData == null)
            {
                mPlayerData = new PlayerData();
                mPlayerData.isBgMusicOpen = true;
                mPlayerData.isSoundOpen = true;
            }
            return mPlayerData;
        } 
    }

    public DataCenter()
    {
    }
}


