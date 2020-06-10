using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditorInternal;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1;
    public float distance;
    Animator enemyAnim;
    public bool Attacking = false;
    public bool Running = false;
    private bool movingRight = true;
    public bool Walking = false;
    public bool Idle = false;
    public PlayerCtrl2 playerCTRL2;
    public Transform groundDetection;
    public GameObject RunningRange;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
             //enemy running
            if (movingRight == true)
            {
                enemyAnim.SetInteger("EnemyCondition", 1);              
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                
            }
            else
            {
                enemyAnim.SetInteger("EnemyCondition", 1);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;                
            }
            
        }

        if (Attacking == true)
        {
            speed = 0;
            enemyAnim.SetInteger("EnemyCondition", 3);
            RunningRange.SetActive(false);
            SoundFXCtrl.PlaySound("EnemyAttacking");
            Debug.Log("Enemy attacking!!!");
        }       
        else
        {
            RunningRange.SetActive(true);
        }

        if (Running == true)
        {
            speed = 3;
            SoundFXCtrl.PlaySound("EnemyRunning");
            SoundFXCtrl.PlaySound("EnemyScream");
            enemyAnim.SetInteger("EnemyCondition", 2);                                   
        }       
        /*else
        {
            Walking = true;
        }*/

        if (Walking == true)
        {
            speed = 1;
            enemyAnim.SetInteger("EnemyCondition", 1);
            SoundFXCtrl.PlaySound("EnemyWalking");
        }
        /*else
        {
            speed = 0;
            enemyAnim.SetInteger("EnemyCondition", 0);
        }*/

        if (Idle == true)
        {
            speed = 0;            
            enemyAnim.SetInteger("EnemyCondition", 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerCTRL2.PlayerIsDead = true;
            Attacking = false;
            Running = false;
            Walking = false;            
            Idle = true;
        }        
    }

    IEnumerator EnemyDelay()
    {        
        yield return new WaitForSeconds(3);
        speed = 0f;
        enemyAnim.SetInteger("EnemyCondition", 0);
        //enemy angry pose before turn left/right
    }
}