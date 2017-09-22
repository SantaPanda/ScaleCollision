using System;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.Diagnostics;

//this class is to help the xmlData class to format the xmlData.
//通用的xml数据处理类。
public class XMLHelper
{
    private static XMLHelper m_Instance;

    public static XMLHelper Instance
    {
        get
        {
            return m_Instance;
        }
    }
    
    public XMLHelper()
    {
    }

    static XMLHelper()
    {
        XMLHelper.m_Instance = new XMLHelper();
    }

    #region Format the Data from xml.
    /*规定：1.所有xml为深度为2的树（根节点的每个子节点是一个数据）
           2.每个数据的各属性记录在item的Attrubutes中.
           3.传入xml的地址，返回Dictionary<int, T>
    */
    public object FormatXMLData<T>(string fileName)
    {
        Dictionary<int, T> map = new Dictionary<int, T>();
        Type type = typeof(T);
        PropertyInfo[] propertyInfos = type.GetProperties();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fileName);

        XmlNode xmlNodeT = xmlDoc.FirstChild;

        XmlNodeList xmlNodeListT = xmlNodeT.ChildNodes;

        foreach (XmlNode tempXmlNode in xmlNodeListT)
        {
            XmlAttributeCollection tempCol = tempXmlNode.Attributes;

            object[] tempParams = new object[tempCol.Count];

            int index = 0;
            int dataId = 0;
            foreach (PropertyInfo tempPropertyInfo in propertyInfos)
            {
                
                try
                {
                    string tempPropertyName = tempPropertyInfo.Name;

                    //get the type of property, in order to create a instance of class T.
                    Type paramType = tempPropertyInfo.PropertyType;
                    if (tempPropertyName.Equals("id"))
                    {
                        dataId = Int32.Parse(tempCol["_id"].Value);
                        tempParams[index++] = dataId;
                    }
                    else if (paramType == typeof(Int32))
                    {
                        tempParams[index++] = Int32.Parse(tempCol[tempPropertyName + "_i"].Value);
                    }
                    else if (paramType == typeof(string))
                    {
                        tempParams[index++] = tempCol[tempPropertyName + "_s"].Value;
                    }
                }
                catch(Exception e)
                {
                    Exception exception = e;
                }
            }
            T tempT = XMLHelper.Create<T>(tempParams);
            map.Add(dataId, tempT);
        }


        object obj = map as Dictionary<int, T>;
        return obj;
    }
    #endregion

    public static T Create<T>(object[] parameters)
    {
        return (T)Activator.CreateInstance(typeof(T), parameters);   
    }
}

