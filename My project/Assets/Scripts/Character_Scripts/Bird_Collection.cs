using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Collection : MonoBehaviour
{
    public int Evidence_Collected;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Evidence_Collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
