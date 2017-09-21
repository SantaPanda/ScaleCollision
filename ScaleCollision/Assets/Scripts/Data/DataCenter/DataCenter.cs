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
  
    public PlayerData PlayerData{ get; set;}

    public DataCenter()
    {
    }
}


