using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{

    void Awake()
    {
        
        int numberOfMPS = FindObjectsOfType<MusicPlayerScript>().Length;
        if(numberOfMPS > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

}
