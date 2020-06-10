using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkingScene : MonoBehaviour
{
    public  int SCENELOAD;
    public void SceneLoaded(int SCENELOAD)
    {
        SceneManager.LoadScene(SCENELOAD);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}    
