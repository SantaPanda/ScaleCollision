using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
        }

        if (go == RegisterButton.gameObject)
        {
            InputPattern.RegisterInputJudge(Account.text, Password.text, CheckPassword.text);
        }
    }
}
