using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour

{

    public static AudioClip playerAttack, playerJump, playerHit, playerDead;
    public static AudioClip buttonClick, collectItem, key, doorOpen;
    static AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("explosion");
        playerJump = Resources.Load<AudioClip>("jump");
        playerHit = Resources.Load<AudioClip>("hitHurt");
        playerDead = Resources.Load<AudioClip>("defeat");
        buttonClick = Resources.Load<AudioClip>("click");
        collectItem = Resources.Load<AudioClip>("itemCollect");
        key = Resources.Load<AudioClip>("pickupCoin");
        doorOpen = Resources.Load<AudioClip>("dooropen");


        src = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "attack":
                src.PlayOneShot(playerAttack);
                break;
            case "jump":
                src.PlayOneShot(playerJump);
                break;
            case "hit":
                src.PlayOneShot(playerHit);
                break;
            case "dead":
                src.PlayOneShot(playerDead);
                break;
            case "click":
                src.PlayOneShot(buttonClick);
                break;
            case "collect":
                src.PlayOneShot(collectItem);
                break;
            case "key":
                src.PlayOneShot(key);
                break;
            case "open":
                src.PlayOneShot(doorOpen);
                break;


        }
    }
}
