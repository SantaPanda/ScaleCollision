using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AboutUsPanel : UIBase
{
    private Button SureButton;

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

        SureButton = transform.Find("SureButton").GetComponent<Button>();
        SureButton.onClick.AddListener(() =>
            {
                this.OnClick(SureButton.gameObject);
            });
    }

    private void OnClick(GameObject go)
    {
        if (go == SureButton.gameObject)
        {
            UIManger.Instance.HidePanel("AboutUsPanel");
        }
    }
}


