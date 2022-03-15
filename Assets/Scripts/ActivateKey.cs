using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKey : PakuHealth
{
    public GameObject activeGameObject;

    [SerializeField]
    public void ActivateObject()
    {
        if (health <= 0)
        {
            activeGameObject.SetActive(true);
        }
        else
        {
            activeGameObject.SetActive(false);
        }

    }
}
