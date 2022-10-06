using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Camera : MonoBehaviour
{
    //creates public transform variables for the head game object and the player camera game object
    public Transform Camera_Reference;
    public Transform Camera_Position;
    // Start is called before the first frame update
    void Start()
    {
        //sets previously created transform variables to the transform coordinates of their respective game objects
        Camera_Reference = GameObject.Find("Camera_Reference").transform;

        Camera_Position = GameObject.Find("PlayerCam").transform; 
        //Camera_Position may not actually be needed since the script is attached
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //Should set the PlayerCam parent object and thus the camera child object to the helmet transform position
        transform.position = Camera_Reference.transform.position;

        print("This is the transform");
        print(transform.position);

        print("This is the head");
        print(Camera_Reference);

        print("This is the Camera_Position");
        print(Camera_Position);

        
    }
}
