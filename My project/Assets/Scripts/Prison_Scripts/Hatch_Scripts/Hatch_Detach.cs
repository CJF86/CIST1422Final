using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch_Detach : MonoBehaviour
{
    public Lever_Rotate Lever;
    // Start is called before the first frame update
    void Start()
    {
        Lever = GameObject.FindGameObjectWithTag("Lever").GetComponent<Lever_Rotate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Lever.Escape_Activated == true)
        {
            transform.DetachChildren();
        }
        
    }
}
