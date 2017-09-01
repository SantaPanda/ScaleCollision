using System.Collections.Generic;

public abstract class ConfigDataT<T> : ConfigData where T : ConfigDataT<T>
{
    private static Dictionary<int, T> m_dataMap = null;

    public static Dictionary<int, T> dataMap
    {
        get
        {
            if (null == m_dataMap)
            {
                m_dataMap = ConfigData.GetDataMap<T>();
            }

            return m_dataMap;
        }
        set
        {
            m_dataMap = value;
        }
    }

    public static void LoadConfig()
    {
        if (null != m_dataMap)
        {
            m_dataMap.Clear();   
        }

        m_dataMap = ConfigData.GetDataMap<T>();
    }

    protected ConfigDataT()
    {
        
    }
}
