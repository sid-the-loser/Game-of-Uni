using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParseScenes
{
    List<string> sceneNames = new List<string>
    {
        "TitleScreen",
        "Tutorial",
        "MainGame",
        "Scoreboard"

    };
    public static int sceneIndex = 0;

    public void CycleScene() 
    {
        sceneIndex++;

        if (sceneIndex >= sceneNames.Count) 
        {
            sceneIndex = 0;
        }

        SceneManager.LoadScene(sceneNames[sceneIndex]);

    }
}
