using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Cycling : MonoBehaviour
{
    public GameObject[] Character_Array;

    public GameObject Character_Spot;

    public GameObject Player_Character;

    public GameObject Character;

    public Vector3 Pos_Trans;

    public int Character_Selection = 0;

    //public bool Character_Destruction = false;
    // Start is called before the first frame update

    public void Start()
    {
        Transform Character_Spot = GameObject.Find("Character_Pos").transform;

        Pos_Trans = Character_Spot.position;

        Player_Character = Character_Array[Character_Selection];

        Character = Instantiate(Player_Character) as GameObject;


    }
    public void Forward_Choice()
    {
        Player_Character = Character_Array[Character_Selection];

        Destroy(Character);
    
        Character_Selection = (Character_Selection + 1) % Character_Array.Length;

        Character = Instantiate(Player_Character,Pos_Trans,Quaternion.identity) as GameObject;

        //Character.transform.position = Pos_Trans;

        Character.transform.Rotate(Vector3.up,180);

        //Character.transform.Translate(Vector3.up * -15);

        Debug.Log("Button being pressed");

    }

    // Update is called once per frame
   
}
