using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch_Script : MonoBehaviour
{
    public Rigidbody Hatch;
    public Lever_Rotate Lever_Trigger;
    public GameObject Escape_Lever;
    // This script handles removing the hatch for the alternate ending
    void Start()
    {
        Escape_Lever = GameObject.FindGameObjectWithTag("Window");

        Hatch = Escape_Lever.GetComponent<Rigidbody>();

        Lever_Trigger = Escape_Lever.GetComponent<Lever_Rotate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent is not null)
        {
            Hatch.useGravity = false;
        }

        if(transform.parent is null)
        {
            Hatch.useGravity = true;
            Hatch.AddForce(Vector3.up*25,ForceMode.Impulse);
        }
    }
}
