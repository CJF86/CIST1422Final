using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Shutoff : MonoBehaviour
{
    
    private Animator Engine_Animator;
    public bool Is_Running = true;
    private bool Interacting;
    void Start()
    {
        Engine_Animator = GetComponentInParent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Interacting = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Interacting = false;
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Interacting with engine");
        if(collision.gameObject.CompareTag("Player") && Interacting)
        {
            Engine_Animator.enabled = false;
            Is_Running = false;
            
        }
    }
}
