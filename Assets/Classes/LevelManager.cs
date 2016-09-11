using UnityEngine;
using System.Collections;

using System.Xml;

public class LevelManager : object {

    public static LevelManager SharedInstance = new LevelManager();

    static LevelManager() { }

    private int currentLevelIndex;
    private string[] levelNames; // = { "Level1", "Level2", "Level3" };

    private LevelManager()
    {
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset textAsset = Resources.Load("levels") as TextAsset;
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level");
        levelNames = new string[levelsList.Count];
        for( int i = 0; i<levelsList.Count && i < levelNames.Length; ++i)
        {
            XmlNode levelNode = levelsList[i]; 
            levelNames[i] = levelNode.InnerText;
        }

        foreach( string levelName in levelNames)
        {
            Debug.Log(levelName);
        }

    }

    public string GetCurrentLevelName()
    {
        if( currentLevelIndex < 0 || currentLevelIndex >= levelNames.Length)
        {
            return "Main";
        }
        return levelNames[currentLevelIndex];
    }

    public void AdvanceLevel()
    {
        currentLevelIndex++;
    }

    public void ResetToFirstLevel()
    {
        currentLevelIndex = 0;
    }

}
