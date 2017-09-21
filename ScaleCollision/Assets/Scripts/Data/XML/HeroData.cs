using System;


public class HeroData :ConfigDataT<HeroData>
{
    public readonly static string fileName;

    public int id{ get; set;}

    /// <summary>
    /// Gets or sets the name of the hero.
    /// </summary>
    /// <value>The name of the hero.</value>
    public string heroName{ get; set;}

    /// <summary>
    /// Gets or sets the name of the hero skill.
    /// </summary>
    /// <value>The name of the hero skill.</value>
    public string skillName{ get; set;}

    /// <summary>
    /// Gets or sets the HS expression.
    /// </summary>
    /// <value>The HS expression.</value>
    public string skillInfo{ get; set;}

    /// <summary>
    /// Gets or sets the hero sprite path.
    /// </summary>
    /// <value>The hero sprite path.</value>
    public string heroSprite{ get; set;}

    /// <summary>
    /// Gets or sets the hero stage show.
    /// </summary>
    /// <value>The hero stage show.</value>
    public string stageShow{ get; set;}

    /// <summary>
    /// Gets or sets the hero portrait.
    /// </summary>
    /// <value>The hero portrait.</value>
    public string portrait{ get; set;}

    public HeroData(int id, string heroName, string skillName, string skillInfo, string heroSprite, string stageShow, string portrait)
    {
        this.id = id;
        this.heroName = heroName;
        this.skillName = skillName;
        this.skillInfo = skillInfo;
        this.heroSprite = heroSprite;
        this.stageShow = stageShow;
        this.portrait = portrait;
    }

    static HeroData()
    {
        fileName = "Assets/Resources/Data/XML/HeroData.xml";
    }
}


