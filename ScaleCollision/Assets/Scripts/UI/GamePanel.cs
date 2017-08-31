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
		JumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        InitialScale();
		JumpButton.onClick.AddListener (()=>{
            ScaleIdList = UIScale.RandomScale(ScaleIdList);
            for(int i=0; i<16; i++){
                ScaleList[i].RefreshUI(ScaleIdList[i], ScaleSprite[ScaleIdList[i]]);
                Debug.Log(ScaleIdList[i] + " ");
            }

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
            ScaleList.Add (new UIScale (i));
        }
    }

}
