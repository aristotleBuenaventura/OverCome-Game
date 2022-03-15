using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogEnd : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    



    private void Start()
    {

        StartCoroutine(Type());


    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
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
            StartCoroutine(WaitForMenu());
           
        }
        IEnumerator WaitForMenu()
        {
            
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Menu Scene");
        }

    }
}
