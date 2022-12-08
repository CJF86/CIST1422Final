using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Shutoff : MonoBehaviour
{
    
    private Animator Engine_Animator;
    public bool Is_Running = true;
    private bool Interacting;
    [SerializeField]
    private AudioClip Engine_Running;
    [SerializeField]
    private AudioClip Engine_Shutdown;
    private AudioSource Engine_Sound;
    void Start()
    {
        Engine_Animator = GetComponentInParent<Animator>();
        Engine_Sound = GetComponentInParent<AudioSource>();
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
            Engine_Sound.loop = false;
            Engine_Sound.PlayOneShot(Engine_Shutdown);
        }
    }
}
