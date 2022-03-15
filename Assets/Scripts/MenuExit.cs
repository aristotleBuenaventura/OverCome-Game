using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu Scene");

    }

    public void Retry()
    {
        Debug.Log(Level.CurrentLevel);
        SceneManager.LoadScene(Level.CurrentLevel);
        PlayerHealth.health = 50;
        SmallPotion.Destroy(gameObject);
        LargePotion.Destroy(gameObject);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
