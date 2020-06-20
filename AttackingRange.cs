using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingRange : MonoBehaviour
{
    public EnemyScript Enemyscript;
    //public GameObject RunningRange;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerPos") //enemy attack the player if player is very close
        {
            //Enemyscript.speed = 0;
            //Enemyscript.Running = false;            
            Enemyscript.Attacking = true;
            //Enemyscript.Walking = false;
            //RunningRange.SetActive(false);            
        }
        else 
        {
            Enemyscript.Attacking = false;            
            //RunningRange.SetActive(true);
            //Enemyscript.Running = true;
        }                        
    }
}
