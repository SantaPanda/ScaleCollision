using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitingPanel : UIBase
{
    private Animator LoadingAnimator;
    private Image LoadingImage;

    public override void OnShow(object param)
    {
        base.OnShow(param);
        AnimationController(true);
        StartCoroutine(StopWaiting());
    }

    public override void OnCreate()
    {
        LoadingImage = transform.Find("BG/WaitingAnimation").GetComponent<Image>();
        LoadingAnimator = LoadingImage.GetComponent<Animator>();
    }

    public override void OnHide()
    {
        base.OnHide();
        AnimationController(false);
        StopCoroutine(StopWaiting());
    }

    IEnumerator StopWaiting()
    {
        while (true)
        {
            AnimatorStateInfo animatorInfo = LoadingAnimator.GetCurrentAnimatorStateInfo(0);
            if ((animatorInfo.normalizedTime >= 1.0f))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
            {
                UIManger.Instance.HidePanel(EnumDataDef.UIPanelType.WaitingPanel.ToString());
                UIManger.Instance.ShowPanel(EnumDataDef.UIPanelType.SelectHeroesPanel.ToString());
                UIManger.Instance.HidePanel(EnumDataDef.UIPanelType.MainPanel.ToString());
            }
            yield return 0;
        }
    }

    public void AnimationController(bool s)
    {
        if (s == true)
        {
            LoadingAnimator.SetTrigger("Waiting");
        }
        else
        {
            LoadingAnimator.SetTrigger("Hide");
        }
    }
}