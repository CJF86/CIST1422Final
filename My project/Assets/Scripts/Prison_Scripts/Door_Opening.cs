using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Opening : MonoBehaviour
{
    public Camera Player_Cam;

    public Camera Mini_Cam;

    public Transform Sliding_Door;

    public GameObject Player;

    public Light Warning_Light;

    float duration = 1.0f;

    public bool Door_Movement;

    public Transform Secondary_Door;

    public bool Door_Trigger = false;

    public float Door_Speed = 0.5f;

    public Win_Condition Door_Puzzle;

    public Canvas PlayerGUI;

    void Start()
    {
        Secondary_Door = GameObject.Find("PrisonDoor2").transform;
        Sliding_Door = GameObject.Find("Sliding_Door").transform;

        Player = GameObject.FindGameObjectWithTag("Player");

        Warning_Light = GameObject.FindGameObjectWithTag("Wall_Light").GetComponent<Light>();

        Player_Cam = GameObject.Find("Camera_Pos").GetComponentInChildren<Camera>();

        Mini_Cam = GameObject.Find("Camera_Holder").GetComponentInChildren<Camera>();

        Door_Puzzle = GameObject.Find("MiniGame").GetComponentInChildren<Win_Condition>();

        PlayerGUI = GameObject.Find("PlayerGUI").GetComponent<Canvas>();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Door_Crack();

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Door_Trigger = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Door_Trigger = false;
        }
        
        if(Door_Movement == true)
        {
            Debug.Log("Door is open");
            Door_Open();
            Light_Flicker();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision register");

        if (collision.gameObject.tag == "Player" && Door_Trigger ==true)
        {
            Debug.Log("Door is sliding");
            collision.gameObject.GetComponent<Character_Movement>().enabled = false;

            Player_Cam.enabled = false;
            Mini_Cam.enabled = true;
            PlayerGUI.enabled = false;
            
            
        }
    }

    public void Door_Crack()
    {
        Debug.Log("Before loop");
        if(Door_Puzzle.Code_Cracked == true)
        {
            Player.GetComponent<Character_Movement>().enabled = true;
            PlayerGUI.enabled = true;
            Mini_Cam.enabled = false;
            Player_Cam.enabled = true;
            Door_Movement = true;
        }
    }

    public void Door_Open()
    {
        Sliding_Door.transform.Translate(-Vector3.forward*Time.deltaTime);
        Secondary_Door.transform.Translate(-Vector3.forward * Time.deltaTime);
    }

    public void Light_Flicker()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        Warning_Light.color = Color.Lerp(Color.white, Color.red, t);
    }
}
