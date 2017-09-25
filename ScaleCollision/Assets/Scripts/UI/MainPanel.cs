using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class MainPanel : UIBase
{
    private Button AboutUsButton;
    private Button SettingButton;
    private Button ShopButton;
    private Button LogButton;
    //private Button Process;

    private Button StartGameButton;
    private Button PortraitButton;

    private readonly string PortraitPath = "Images/UI/SelectHeroesPanel/Portrait/{0}";

    private Text UserName;
    private Text Golds;
    private Text Cash;

    public override void OnShow(object param)
    {
        base.OnShow(param);

        AudioManager.Instance.PlayAudio(BGMId.MainPanelBGM.ToString(), loop: true, type: EnumDataDef.AudioType.BgMusic);
        this.RefreshUI();
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
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.AboutUsPanel.ToString());
        }

        if (go == SettingButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.SettingPanel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.MainPanel.ToString());
        }

        if (go == ShopButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.ShopPanel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.MainPanel.ToString());
        }

        if (go == LogButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.LogPanel.ToString());
        }

        if (go == StartGameButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.WaitingPanel.ToString());
        }

        if (go == PortraitButton.gameObject)
        {
        }
    }

    public override void RefreshUI()
    {
        base.RefreshUI();

        UserName.text = DataCenter.Instance.playerData.name;
        Golds.text = DataCenter.Instance.playerData.golds.ToString();
        Cash.text = DataCenter.Instance.playerData.cash.ToString();

        if (HeroData.dataMap.ContainsKey(DataCenter.Instance.playerData.PortraitId))
        {
            string portraitName = HeroData.dataMap[DataCenter.Instance.playerData.PortraitId].portrait;
            PortraitButton.image.sprite = Resources.Load(string.Format(PortraitPath, portraitName), typeof(Sprite)) as Sprite;
        }
        if (!DataCenter.Instance.playerData.isBgMusicOpen)
        {
            AudioManager.Instance.StopAudio(BGMId.MainPanelBGM.ToString());
        }
    }
}
