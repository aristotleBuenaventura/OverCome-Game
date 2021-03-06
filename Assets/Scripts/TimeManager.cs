using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    
    
    public float startingTime;

    private Text theText;

    // Start is called before the first frame update
    void Start()
    {
      
        theText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;

        if(startingTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        theText.text = "" + Mathf.Round(startingTime);
    }
}
