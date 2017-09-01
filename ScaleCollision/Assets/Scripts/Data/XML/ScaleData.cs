using UnityEngine;
using System.Collections;

public class ScaleData : ConfigDataT<ScaleData>
{
    public readonly static string fileName;
   
    public int id{ get; set;}

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string name{ get; set;}

    /// <summary>
    /// Gets or sets the image path of Scale.
    /// </summary>
    /// <value>The image path.</value>
    public string imagePath{ get; set;}

    public ScaleData(int id, string name, string imagePath)
    {
        this.id = id;
        this.name = name;
        this.imagePath = imagePath;
    }

    static ScaleData()
    {
        ScaleData.fileName = "Assets/Resources/Data/XML/ScaleData.xml";    
    }
}
