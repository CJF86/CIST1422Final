using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Link : MonoBehaviour
{
    public Camera Selection_Camera;
    public Camera Player_Camera;
    public Transform Camera_Container;
    public string Selection_Scene;
    
    void Start()
    {
        Camera_Container = GameObject.Find("Camera_Pos").transform;

        Selection_Scene = SceneManager.GetActiveScene().name;

        transform.Rotate(-90, 0, -180);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera_Container.transform.position;

        //Camera_Control();
        
    }

    public void Camera_Control()
    {
        if(Selection_Scene == "Character_Selection")
        {
            Selection_Camera.enabled = true;
            Player_Camera.enabled = false;
        }
        else
        {
            Selection_Camera.enabled = false;
            Player_Camera.enabled = true;
        }



    }
}