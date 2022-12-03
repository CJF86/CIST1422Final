using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Enter : MonoBehaviour
{
    private GameObject Player;
    private Camera Mini_Camera;
    public Camera Player_Cam;
    private bool Ship_Trigger;

    void Start()
    {
        Mini_Camera = GameObject.Find("Camera_Holder").GetComponentInChildren<Camera>();
        Player_Cam = GameObject.Find("Camera_Pos").GetComponentInChildren<Camera>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Ship_Trigger = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Ship_Trigger = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision register");

        if (collision.gameObject.tag == "Player" && Ship_Trigger == true)
        {
            
            collision.gameObject.GetComponent<Character_Movement>().enabled = false;

            Player_Cam.enabled = false;
            Mini_Camera.enabled = true;
            


        }
    }
}
