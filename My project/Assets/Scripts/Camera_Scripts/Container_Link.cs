using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Link : MonoBehaviour
{
    public Transform Player_Eyes;
    private float Character_Turn_Speed = 20f;
    public float Y_Input;
    public float Mouse_Value;
    public GameObject Player_Character;
    public bool Script_Active = true;
    //public AudioSource Player_Audio;
    //public AudioClip Walking_Sound;

    //public AudioClip Attacking_Sound;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Eyes = GameObject.Find("Man_Eyes_Mesh").transform;

        Player_Character = GameObject.FindGameObjectWithTag("Player");

        //transform.position = Player_Eyes.transform.position;

        transform.rotation = Player_Eyes.transform.rotation;

        if(Player_Character.GetComponent<Character_Movement>().enabled == false)
        {
            Debug.Log("Script is false");
            Script_Active = false;
        }
        else
        {
            Debug.Log("Script is true");
            Script_Active = true;
        }


        Y_Rotation();
        
    }

    public void Y_Rotation()
    {
        Mouse_Value = Input.GetAxis("Mouse Y");


        Vector3 Turn_Vector = new Vector3();

        Turn_Vector.x += Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        //Changing Mouse_Value from negative to positive
        //if statement not triggering for some reason
        /*
        if(Turn_Vector.x >= 38)
        {
            Turn_Vector.x = 38;
            Debug.Log("Max trigger");
        }

        if(Turn_Vector.x <= -13)
        {
            Turn_Vector.x = -13;
            Debug.Log("Min trigger");
        }
        */

        Quaternion Turn = Quaternion.Euler(Turn_Vector);

        Player_Eyes.transform.Rotate(Turn_Vector, Space.Self);

    }

    
}
