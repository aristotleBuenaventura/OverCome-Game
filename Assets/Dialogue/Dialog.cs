using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject box;
    public Player1 player;
    public GameObject barrier;
    public TimeManager timer;


    private void Start()
    {
        
        StartCoroutine(Type());
        player.enabled = false;
        barrier.SetActive(true);
        timer.enabled = false;
        
    }

    private void Update()
    {
        if(textDisplay.text== sentences[index])
        {
            continueButton.SetActive(true);
        }
 
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }   

    }

    public void nextSentence()
    {
        
        
        continueButton.SetActive(false);
        

        if (index < sentences.Length - 1)
        {
            SoundManagerScript.PlaySound("click");
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            box.SetActive(false);
            player.enabled = true;
            barrier.SetActive(false);
            timer.enabled = true;


        }
    }
    
}
