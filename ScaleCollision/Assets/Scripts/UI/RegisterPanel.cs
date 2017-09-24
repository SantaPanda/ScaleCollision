using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class RegisterPanel : UIBase 
{
    private Text Account;
    private Text Password;
    private Text CheckPassword;

    private Button ReturnButton;
    private Button RegisterButton;

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

        Account = transform.Find("RegisterContent/AccountText/InputField/Text").GetComponent<Text>();
        Password = transform.Find("RegisterContent/PasswordText/InputField/Text").GetComponent<Text>();
        CheckPassword = transform.Find("RegisterContent/CheckPasswordText/InputField/Text").GetComponent<Text>();
       
        ReturnButton = transform.Find("RegisterContent/ReturnButton").GetComponent<Button>();
        ReturnButton.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton.gameObject);
            });
        RegisterButton = transform.Find("RegisterContent/RegisterButton").GetComponent<Button>();
        RegisterButton.onClick.AddListener(() =>
            {
                this.OnClick(RegisterButton.gameObject);
            });
    }

    private void OnClick(GameObject go)
    {
        if (go == ReturnButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.HidePanel(UIPanelType.RegisterPanel.ToString());
        }

        if (go == RegisterButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            int inputType = InputPattern.RegisterInputJudge(Account.text, Password.text, CheckPassword.text);
            if (inputType == 1)
            {
                httpClient http = new httpClient();
                int response = http.Register(Account.text, Password.text);
                if (response == 1)
                {
                    TipPanel.ShowTip("恭喜，注册成功！");
                }
                else
                {
                    TipPanel.ShowTip("抱歉，注册失败！");
                }
            }
            else if (inputType == 0)
            {
                TipPanel.ShowTip("账号或密码不符合要求！");
            }
            else
            {
                TipPanel.ShowTip("两次密码输入不同！");
            }
        }
    }
}
