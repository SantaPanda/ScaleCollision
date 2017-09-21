using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainPanel : UIBase
{
    private Button AboutUsButton;
    private Button SettingButton;
    private Button ShopButton;
    private Button LogButton;
    //private Button Process;

    private Button StartGameButton;
    private Button PortraitButton;

    private Text UserName;
    private Text Golds;
    private Text Cash;

    public override void OnShow(object param)
    {
        base.OnShow(param);
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        AboutUsButton = transform.Find("AboutUs").GetComponent<Button>();
        AboutUsButton.onClick.AddListener(() =>
            {
                this.OnClick(AboutUsButton.gameObject);
            });
        SettingButton = transform.Find("Setting/Space").GetComponent<Button>();
        SettingButton.onClick.AddListener(() =>
            {
                this.OnClick(SettingButton.gameObject);
            });
        ShopButton = transform.Find("Shop/Space").GetComponent<Button>();
        ShopButton.onClick.AddListener(() =>
            {
                this.OnClick(ShopButton.gameObject);
            });
        LogButton = transform.Find("Log/Space").GetComponent<Button>();
        LogButton.onClick.AddListener(() =>
            {
                this.OnClick(LogButton.gameObject);
            });

        StartGameButton = transform.Find("StartGame").GetComponent<Button>();
        StartGameButton.onClick.AddListener(() =>
            {
                this.OnClick(StartGameButton.gameObject);
            });
        PortraitButton = transform.Find("Portrait").GetComponent<Button>();
        PortraitButton.onClick.AddListener(() =>
            {
                this.OnClick(PortraitButton.gameObject);
            });

        UserName = transform.Find("Name").GetComponent<Text>();
        Golds = transform.Find("Golds").GetComponent<Text>();
        Cash = transform.Find("Cash").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        if (go == AboutUsButton.gameObject)
        {
            UIManger.Instance.ShowPanel("AboutUsPanel");
        }

        if (go == SettingButton.gameObject)
        {
        }

        if (go == ShopButton.gameObject)
        {
        }

        if (go == LogButton.gameObject)
        {
        }

        if (go == StartGameButton.gameObject)
        {
        }

        if (go == PortraitButton.gameObject)
        {
        }
    }
}
