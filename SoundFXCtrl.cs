using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXCtrl : MonoBehaviour
{
    public static AudioClip PWalking, PJumping, PDie, EWalking, ERunning, EAttacking, EScream;
    static AudioSource audioSrc;
    void Start()
    {
        PWalking = Resources.Load<AudioClip>("PlayerWalking");
        PJumping = Resources.Load<AudioClip>("PlayerJumping");
        PDie = Resources.Load<AudioClip>("PlayerDie");

        EWalking = Resources.Load<AudioClip>("EnemyWalking");
        ERunning = Resources.Load<AudioClip>("EnemyRuning");
        EAttacking = Resources.Load<AudioClip>("EnemyAttacking");
        EScream = Resources.Load<AudioClip>("EnemyScream");

        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PlayerWalking":
                audioSrc.PlayOneShot(PWalking);
                break;

            case "PlayerJumping":
                audioSrc.PlayOneShot(PJumping);
                break;

            case "PlayerDie":
                audioSrc.PlayOneShot(PDie);
                break;

            case "EnemyWalking":
                audioSrc.PlayOneShot(EWalking);
                break;

            case "EnemyRunning":
                audioSrc.PlayOneShot(ERunning);
                break;

            case "EnemyAttacking":
                audioSrc.PlayOneShot(EAttacking);
                break;

            case "EnemyScream":
                audioSrc.PlayOneShot(EScream);
                break;

        }
    }
}
