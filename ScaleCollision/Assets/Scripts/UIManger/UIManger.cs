using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManger
{
    /// <summary>
    /// The static UIManger instance.
    /// </summary>
    private static UIManger mInstance;
   
    public static UIManger Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new UIManger();
            }
            return mInstance;
        }
    }

    /// <summary>
    /// The RootGameobject of this game.
    /// ALL panels add to this rootGameObject.
    /// </summary>
    private Transform mCanvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (mCanvasTransform == null)
            {
                mCanvasTransform = GameObject.Find("UICamera/Canvas").transform;
            }
            return mCanvasTransform;
        }
    }

    private static readonly string UIPrefabsPath = "Prefabs/UI/{0}";

    /// <summary>
    /// 保存所有界面的UIBase组件。
    /// </summary>
    private Dictionary<EnumDataDef.UIPanelType, UIBase> mDicUI;

    private static readonly string StartPanel = "LoginPanel";

    /// <summary>
    /// 添加UI（用于管理）
    /// </summary>
    /// <param name="UIType">UI界面的类型，枚举列出</param>
    /// <param name="newUI">New U.</param>
    public void AddUI(EnumDataDef.UIPanelType UIType,UIBase newUI)
    {
        if (newUI != null && UIType != null)
        {
            mDicUI.Add(UIType, newUI);
        }   
    }

    /// <summary>
    /// 移除一个UI
    /// </summary>
    /// <param name="UIType">UI界面的类型，枚举列出</param>
    /// <param name="oldUI">Old U.</param>
    public void RemoveUI(EnumDataDef.UIPanelType UIType, UIBase oldUI)
    {
        if (oldUI != null && UIType != null)
        {
            mDicUI.Remove(UIType);
        }
    }

    /// <summary>
    /// 游戏开始时，初始化和加载所有界面。
    /// </summary>
    public void InitAllUI()
    {
        foreach (EnumDataDef.UIPanelType tempUIPanelType in System.Enum.GetValues(typeof(EnumDataDef.UIPanelType)))
        {
            if (tempUIPanelType != null)
            {
                UIBase panel = GetUIPanel(tempUIPanelType);
                panel.OnCreate();
            }
            if (tempUIPanelType.ToString().Equals("MainPanel"))
            {
                UIBase panel = GetUIPanel(tempUIPanelType);
                panel.OnShow();
            }
        }
    }

    /// <summary>
    /// Shows the panel.
    /// </summary>
    /// <param name="UIPanelName">User interface panel name.</param>
    public void ShowPanel(string UIPanelName)
    {
        foreach (EnumDataDef.UIPanelType tempUIPanelType in System.Enum.GetValues(typeof(EnumDataDef.UIPanelType)))
        {
            if (tempUIPanelType.ToString().Equals(UIPanelName))
            {
                UIBase panel = GetUIPanel(tempUIPanelType);
                panel.OnShow();
            }
        }
    }

    public void HidePanel(string UIPanelName)
    {
        foreach (EnumDataDef.UIPanelType tempUIPanelType in System.Enum.GetValues(typeof(EnumDataDef.UIPanelType)))
        {
            if (tempUIPanelType.ToString().Equals(UIPanelName))
            {
                UIBase panel = GetUIPanel(tempUIPanelType);
                panel.OnHide();
            }
        }
    }

    /// <summary>
    /// Gets the UIPanel of this UIPanelType.
    /// 获取该UI界面的代码组件。
    /// </summary>
    /// <returns>The UIpanel.</returns>
    /// <param name="panelType">Panel type.</param>
    public UIBase GetUIPanel(EnumDataDef.UIPanelType panelType)
    {
        if (mDicUI == null)
        {
            mDicUI = new Dictionary<EnumDataDef.UIPanelType, UIBase>();
        }
            
        UIBase panel;
        bool isGetPanel = mDicUI.TryGetValue(panelType, out panel);

        if (!isGetPanel || panel == null)
        {
            GameObject newGo = GameObject.Instantiate(Resources.Load(string.Format(UIPrefabsPath, panelType.ToString()+"/"+panelType.ToString())), Vector3.zero, Quaternion.identity) as GameObject;

            newGo.transform.SetParent(CanvasTransform, false);
            newGo.transform.localPosition = Vector3.zero;
            newGo.name = panelType.ToString();

            panel = newGo.GetComponent<UIBase>();
            mDicUI.Add(panelType, panel);
        }

        return panel;
    }
}
