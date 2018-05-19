using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NotDestroyObject : MonoBehaviour
{
    public GameObject[] NotDestroy;
   
    void Start()
    {
        for (int i = 0; i < NotDestroy.Length; i++)
        {
            DontDestroyOnLoad(NotDestroy[i]);
        }
    } 
}
