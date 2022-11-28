using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Condition : MonoBehaviour
{
    public bool Code_Cracked = false;

    public Transform Switch1;
    public Transform Switch2;
    public Transform Switch3;
    public Transform Switch4;
    public Transform Switch5;
    public AudioSource Short_Circuit;
    public AudioClip Breaker_Sound;
    public AudioClip Breaker_Fail;
    public Canvas PlayerGUI;
    public GameObject Player;
    public Camera Player_Cam;
    private Player_Health player_Health;
    public Camera Mini_Cam;
    public Electrical_Mini Electrical_Check;

    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        player_Health = Player.GetComponent<Player_Health>();
        Player_Cam = GameObject.Find("Camera_Pos").GetComponentInChildren<Camera>();
        Mini_Cam = GameObject.Find("Camera_Holder").GetComponentInChildren<Camera>();
        PlayerGUI = GameObject.Find("PlayerGUI").GetComponent<Canvas>();
        Short_Circuit = GetComponent<AudioSource>();
        Switch1 = transform.Find("Switch1");
        Switch2 = transform.Find("Switch2");
        Switch3 = transform.Find("Switch3");
        Switch4 = transform.Find("Switch4");
        Switch5 = transform.Find("Switch5");
    }

    
    

    public void Game_Beat()
    {
        if(Switch1.GetComponent<Electrical_Mini>().Is_Active == false && Switch2.GetComponent<Electrical_Mini>().Is_Active == true && Switch3.GetComponent<Electrical_Mini>().Is_Active == true && Switch4.GetComponent<Electrical_Mini>().Is_Active == false && Switch5.GetComponent<Electrical_Mini>().Is_Active == true)
        {
            Code_Cracked = true;
            Short_Circuit.PlayOneShot(Breaker_Sound);
            
        }
        else
        {
            Code_Cracked = false;
            Player.GetComponent<Character_Movement>().enabled = true;
            PlayerGUI.enabled = true;
            Mini_Cam.enabled = false;
            Player_Cam.enabled = true;
            Short_Circuit.PlayOneShot(Breaker_Fail);
            player_Health.Total_Health -= 10;

        }
        
    }

    
}
