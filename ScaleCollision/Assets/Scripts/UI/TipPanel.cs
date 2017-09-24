using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class TipPanel : UIBase
{
    private Button SureButton;
    private Button ReturnButton1;
    private Button ReturnButton2;

    private Text Tip;
    public static string message = "";

    public override void OnShow(object param)
    {
        base.OnShow(param);

        this.RefreshMessage();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        SureButton = transform.Find("SureButton").GetComponent<Button>();
        SureButton.onClick.AddListener(() =>
            {
                this.OnClick(SureButton.gameObject);
            });
        ReturnButton1 = transform.Find("ReturnButton1").GetComponent<Button>();
        ReturnButton1.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton1.gameObject);
            });
        ReturnButton2 = transform.Find("ReturnButton2").GetComponent<Button>();
        ReturnButton2.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton2.gameObject);
            });

        Tip = transform.Find("Tip").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        if (go == SureButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.HidePanel(UIPanelType.TipPanel.ToString());
        }

        if (go == ReturnButton1.gameObject)
        {
        }

        if (go == ReturnButton2.gameObject)
        {
        }
    }

    private void RefreshMessage()
    {
        Tip.text = message;
    }

    public static void ShowTip(string message)
    {
        TipPanel.message = message;
        UIManger.Instance.ShowPanel(UIPanelType.TipPanel.ToString());
    }
}


