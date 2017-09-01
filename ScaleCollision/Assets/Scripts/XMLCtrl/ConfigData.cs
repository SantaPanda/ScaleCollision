using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

public abstract class ConfigData
{
    protected ConfigData()
    {
    }

    protected static Dictionary<int, T> GetDataMap<T>()
    {
        Dictionary<int, T> dataMap = null;
        //测量程序运行时间
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Type type = typeof(T);
        FieldInfo fileNameField = type.GetField("fileName");
        bool flag = fileNameField == null;
        if (flag)
        {
            dataMap = new Dictionary<int, T>();
        }
        else
        {
            string fileName = fileNameField.GetValue(null) as string;
            object result = XMLHelper.Instance.FormatXMLData<T>(fileName);
            dataMap = result as Dictionary<int, T>;
        }
        sw.Stop();
        // LoggerHelper.Info(string.Concat(type, " time: ", sw.ElapsedMilliseconds), true);
        Dictionary<int, T> nums = dataMap;
        return nums;
    }
}

