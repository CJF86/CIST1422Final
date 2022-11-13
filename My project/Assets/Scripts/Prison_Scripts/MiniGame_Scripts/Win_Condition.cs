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

    public Electrical_Mini Electrical_Check;

    void Start()
    {
        Switch1 = transform.Find("Switch1");
        Switch2 = transform.Find("Switch2");
        Switch3 = transform.Find("Switch3");
        Switch4 = transform.Find("Switch4");
        Switch5 = transform.Find("Switch5");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Game_Beat();
    }

    public void Game_Beat()
    {
        if(Switch1.GetComponent<Electrical_Mini>().Is_Active == false && Switch2.GetComponent<Electrical_Mini>().Is_Active == true && Switch3.GetComponent<Electrical_Mini>().Is_Active == true && Switch4.GetComponent<Electrical_Mini>().Is_Active == false && Switch5.GetComponent<Electrical_Mini>().Is_Active == true)
        {
            Code_Cracked = true;
            
        }
        else
        {
            Code_Cracked = false;
            
        }
        
    }

    
}
