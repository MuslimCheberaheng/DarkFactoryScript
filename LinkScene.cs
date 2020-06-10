using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkScene : MonoBehaviour
{        
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
