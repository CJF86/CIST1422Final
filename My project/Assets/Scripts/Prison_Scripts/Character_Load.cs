using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Load : MonoBehaviour
{
    public int Character_Choice;
    public GameObject[] Chosen_Character;
    public Vector3 Pos_Trans;
    public GameObject Player_Character;
    // This script loads the chosen character from the start scene
    void Start()
    {
        Transform Character_Spot = GameObject.Find("Character_Pos").transform;

        Pos_Trans = Character_Spot.position;

        Character_Choice = PlayerPrefs.GetInt("Character_Selection");

        Debug.Log(Character_Choice);

        Player_Character = Instantiate(Chosen_Character[Character_Choice],Pos_Trans, Quaternion.identity) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
