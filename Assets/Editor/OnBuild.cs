using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Linq;
using System.Collections.Generic;

[InitializeOnLoad]
public class OnBuild : object
{

    static OnBuild()
    {

        EditorApplication.playmodeStateChanged = () => {

            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {

                DirectoryInfo info = new DirectoryInfo("Assets/Levels");
                FileInfo[] files = info.GetFiles();
                files.OrderBy(f => f.Name);

                HashSet<string> paths = new HashSet<string>();

                foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
                {
                    string path = scene.path;
                    paths.Add(path);
                }

                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("levels");
                xmlDoc.AppendChild(rootNode);

                string extension = ".unity";

                foreach (FileInfo file in files)
                {
                    string currentExtension = file.Extension;
                    if (currentExtension.Equals(extension))
                    {
                        string path = file.FullName;
                        if (!paths.Contains(path) && !paths.Contains(path + extension))
                        {
                            paths.Add(path);
                        }
                        XmlNode levelNode = xmlDoc.CreateElement("level");
                        levelNode.InnerText = file.Name.Replace(extension, "");
                        rootNode.AppendChild(levelNode);
                    }
                }

                xmlDoc.Save("Assets/Resources/levels.xml");

                EditorBuildSettingsScene[] scenesNew = new EditorBuildSettingsScene[paths.Count];

                int i = 0;
                foreach (string path in paths)
                {
                    EditorBuildSettingsScene scene = new EditorBuildSettingsScene(path, true);
                    scenesNew[i] = scene;
                    ++i;
                }

                if (scenesNew != null)
                {
                    EditorBuildSettings.scenes = scenesNew;
                }
            }
        };

    }
}