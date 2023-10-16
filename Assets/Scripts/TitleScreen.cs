using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BetweenSceneInputManager.currentInputID == -1)
        {
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            BetweenSceneInputManager.currentInputID = -1;
        }

    }
}
