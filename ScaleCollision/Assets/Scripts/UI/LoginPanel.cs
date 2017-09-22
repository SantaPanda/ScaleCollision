using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class LoginPanel : UIBase
{

    private Text Account;
    private Text Password;
    private Button LoginButton;
    private Button RegisterButton;

    public override void OnShow(object param)
    {
        base.OnShow(param);

        AudioManager.Instance.PlayAudio(BGMId.LoginBGM.ToString(), loop: true, type: EnumDataDef.AudioType.BgMusic);
    }

    public override void OnHide()
    {
        base.OnHide();

        AudioManager.Instance.StopAudio(BGMId.LoginBGM.ToString());
    }

    public override void OnCreate()
    {
        base.OnCreate();

        Account = transform.Find("LoginContent/AccountText/InputField/Text").GetComponent<Text>();
        Password = transform.Find("LoginContent/PasswordText/InputField/Text").GetComponent<Text>();

        LoginButton = transform.Find("LoginContent/LoginButton").GetComponent<Button>();
        LoginButton.onClick.AddListener(() =>
            {
                this.OnClick(LoginButton.gameObject);
            });
        RegisterButton = transform.Find("LoginContent/RegisterButton").GetComponent<Button>();
        RegisterButton.onClick.AddListener(() =>
            {
                this.OnClick(RegisterButton.gameObject);
            });
    }

    private void OnClick(GameObject go)
    {
        if (go == LoginButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.MainPanel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.LoginPanel.ToString());
        }

        if (go == RegisterButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.RegisterPanel.ToString());
        }
    }
}


