using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
    public GameObject player;
    public bool disabled = false;
    
    void Update()
    {
        if(disabled == true)
        {
            player.SetActive(false);
        }
        else
        {
            player.SetActive(true);
        }
    }    
}
