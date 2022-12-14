using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Cycling : MonoBehaviour
{
    //This script handles the button events used for selecting the player character
    //This script also handles the play button and is used to load the next scene/save player character choice

    public GameObject[] Character_Array;

    public GameObject Character_Spot;

    public GameObject Player_Character;

    public GameObject Character;

    public Vector3 Pos_Trans;

    public int Character_Selection = 0;

    

    //changed from start to awake
    public void Awake()
    {
        Transform Character_Spot = GameObject.Find("Character_Pos").transform;

        Pos_Trans = Character_Spot.position;

        Player_Character = Character_Array[Character_Selection];

        Character = Instantiate(Player_Character,Pos_Trans, Quaternion.identity) as GameObject;

        Character.transform.Rotate(Vector3.up, 180);
    }
    public void Forward_Choice()
    {
        
        Destroy(Character);
    
        Character_Selection = (Character_Selection + 1) % Character_Array.Length;

        Player_Character = Character_Array[Character_Selection];

        Character = Instantiate(Player_Character,Pos_Trans,Quaternion.identity) as GameObject;

        //Character.transform.position = Pos_Trans;

        Character.transform.Rotate(Vector3.up,180);

        //Character.transform.Translate(Vector3.up * -15);

        //Debug.Log(Character_Selection);

    }

    public void Backward_Choice()
    {
        //Player_Character = Character_Array[Character_Selection];

        Destroy(Character);

        Character_Selection = (Character_Selection - 1);

        if(Character_Selection < 0)
        {
            Character_Selection += Character_Array.Length;
        }

        Player_Character = Character_Array[Character_Selection];

        Character = Instantiate(Player_Character, Pos_Trans, Quaternion.identity) as GameObject;

        //Character.transform.position = Pos_Trans;

        Character.transform.Rotate(Vector3.up, 180);

        Debug.Log(Character.name);
        Debug.Log(Character_Selection);
    }

    public void Start_Game()
    {
        PlayerPrefs.SetInt("Character_Selection", Character_Selection);
        Debug.Log("Should be " + Character_Selection);
        SceneManager.LoadScene("Prison_Scene",LoadSceneMode.Single);

    }

    
   
}
