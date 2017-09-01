using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GamePanel : MonoBehaviour 
{

	private Button JumpButton;
	private Button SkillButton;

    private List<int> ScaleIdList = new List<int>();
    private List<Sprite> ScaleSprite = new List<Sprite>();
	private List<UIScale> ScaleList = new List<UIScale>();

	// Use this for initialization
	void Awake () 
	{
		OnCreate ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnCreate()
	{
        InitialScale();
        
		JumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        SkillButton = GameObject.Find("SkillButton").GetComponent<Button>();
        JumpButton.onClick.AddListener(() =>
            {
                this.OnClick(JumpButton.gameObject);
            });
        SkillButton.onClick.AddListener(() =>
            {
                this.OnClick(SkillButton.gameObject);
            });
	}

    public void InitialScale()
    {
        string path1 = "Images/UI/GamePanel/left{0}";
        string path2 = "Images/UI/GamePanel/right{0}";
        for (int i = 0; i < 8; i++)
        {
            Sprite tempSprite = Resources.Load(string.Format(path1, i), typeof(Sprite)) as Sprite;
            ScaleSprite.Add(tempSprite);
        }
        for (int i = 0; i < 8; i++)
        {
            Sprite tempSprite = Resources.Load(string.Format(path2, i), typeof(Sprite)) as Sprite;
            ScaleSprite.Add(tempSprite);
        }

        for (int i = 0; i < 16; i++) 
        {
            ScaleIdList.Add(i);
            ScaleList.Add (new UIScale(i));
        }
    }

    public void OnClick(GameObject go)
    {
        if (go == JumpButton.gameObject)
        {
            ScaleIdList = UIScale.RandomScale(ScaleIdList);
            for(int i=0; i<16; i++){
                ScaleList[i].RefreshUI(ScaleIdList[i], ScaleSprite[ScaleIdList[i]]);
            }
        }
        if (go == SkillButton.gameObject)
        {
        }
    }

    public void OnHide()
    {
        transform.gameObject.SetActive(false);
    }
}
