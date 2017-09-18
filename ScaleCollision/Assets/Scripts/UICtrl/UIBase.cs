using System;
using System.Collections;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    /// <summary>
    /// 当前界面的名字
    /// </summary>
    public string UIName;

    private Transform mTransform;
    public Transform CacheTransform
    {
        get
        {
            if (mTransform == null)
            {
                mTransform = this.transform;
            }
            return mTransform;
        }   
    }

    private GameObject mGo;
    public GameObject CacheGameObject
    {
        get
        {
            if (mGo == null)
            {
                mGo = this.gameObject;
            }
            return mGo;
        }
    }

    /// <summary>
    /// 初始化当前界面.
    /// </summary>
    protected virtual void UIInit()
    {
    }

    /// <summary>
    /// 用于绑定脚本和初始化gameobjects.
    /// </summary>
    public virtual void OnCreate()
    {
    }

    /// <summary>
    /// 显示当前的UI
    /// </summary>
    /// <param name="param">Parameter.</param>
    public virtual void OnShow(object param=null)
    {
        CacheGameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏当前的UI
    /// </summary>
    public virtual void OnHide()
    {
        CacheGameObject.SetActive(false);
    }

    public virtual void RefreshUI()
    {
        
    }

    /// <summary>
    /// /*Adds the element.*/
    /// </summary>
    /// <returns>The element.</returns>
    /// <param name="childNode">Child node.</param>
    /// <param name="name">Name.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public T AddElement<T>(string childNode, string name) where T : UIBase
    {
        T element = null;
        Transform parent;
        GameObject child = transform.Find(childNode).gameObject;

        int index = childNode.IndexOf('/');
        if (index < 0)
        {
            parent = this.transform;
        }
        else
        {
            parent = transform.Find(childNode.Substring(0, childNode.LastIndexOf('/')));
        }

        GameObject go = Instantiate(child, Vector3.zero, Quaternion.identity) as GameObject;

        if (parent != null)
        {
            go.transform.SetParent(parent);

            go.name = name;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
        }

        element = go.GetComponent(typeof(T)) as T;
        if (element == null)
        {
            element = go.AddComponent(typeof(T)) as T;
        }

        element.OnCreate();
        element.OnShow();

        return element;
    }
}


