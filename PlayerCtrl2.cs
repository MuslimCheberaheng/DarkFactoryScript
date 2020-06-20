using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl2 : MonoBehaviour
{

    public LinkScene linkingScene;
    Rigidbody2D rb;
    public float speedPlayer;
    public float jumpingHight;
    SpriteRenderer SRflip;
    Animator anim;
    private BoxCollider2D BoxCol;
    [SerializeField] private LayerMask Groundlayermask;        
    public bool hiding = false;
    public DisablePlayer disablePLAYER;
    public GameObject PLAYER;
    public GameObject hidingPlayer;
    public bool PlayerIsDead = false;
    public GameObject hidingSign;
    public static bool GameIsPause = false; //pause the game 
    public GameObject pauseBUTTON;       
    public int HidingLayer = 0; //to hiding behind the box
    public int normalLayer = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SRflip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        BoxCol = GetComponent<BoxCollider2D>();
        hidingSign.SetActive(false);        
    }

    void Update()
    {
        float Playspeed = Input.GetAxisRaw("Horizontal");
        Playspeed *= speedPlayer;

        if (Playspeed != 0)
        {
            MoveHorizontal(Playspeed);
        }
        else
        {
            Movestop();
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpingHight;
            anim.Play("Player_Jump");
            SoundFXCtrl.PlaySound("PlayerJumping");
        }        

        if(hiding == true)
        {
            gameObject.layer = LayerMask.NameToLayer("HidableOBJ");
            hidingPlayer.SetActive(false);                               
            Debug.Log("You are Hiding behind Box");            
        }
        else 
        {
            hidingPlayer.SetActive(true);
            //PLAYER.layer = 2;
            Debug.Log("You are not hiding");            
        }

        if(PlayerIsDead == true)
        {
            SoundFXCtrl.PlaySound("PlayerDie");
            StartCoroutine(SetDelayDead());
            anim.Play("Player_Dead");
            speedPlayer = 0;
            Debug.Log("Player is dead");            
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //pause the game 
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void MoveHorizontal(float Playspeed)
    {
        rb.velocity = new Vector2(Playspeed, rb.velocity.y);
        
        if (Playspeed < 0)
        {
            SRflip.flipX = true;            
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speedPlayer = 3;
                Debug.Log(speedPlayer);
                
            }
            else
            {
                speedPlayer = speedPlayer;
            }
        }
        if (Playspeed > 0)
        {
            SRflip.flipX = false;            
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speedPlayer = 3;
                Debug.Log(speedPlayer);                
            }
            else
            {
                speedPlayer = speedPlayer;
            }
        }
        anim.SetInteger("condition", 1);
        SoundFXCtrl.PlaySound("PlayerWalking");
    }

    public void Movestop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetInteger("condition", 0); //Idle
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {                        
        if (collision.gameObject.tag == "box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                hiding = true;
                hidingSign.SetActive(true);
                SRflip.sortingOrder = HidingLayer;                
            }
            else
            {
                hiding = false;
                hidingSign.SetActive(false);
                SRflip.sortingOrder = normalLayer;                                
            }
        }        
    }

    public void PlayerDie()
    {
        anim.SetInteger("condition", 2);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(BoxCol.bounds.center, BoxCol.bounds.size, 0f, Vector2.down, .1f, Groundlayermask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null; //for jumping one time only
    }

    IEnumerator SetDelayDead()
    {
        yield return new WaitForSeconds(3);                
        linkingScene.LoadScene("DeadScene");//go to next scene
        Debug.Log("Go Dead Scene");
    }

    public void Resume()
    {
        pauseBUTTON.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        pauseBUTTON.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
    
