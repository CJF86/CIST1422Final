using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Alarm_Trigger : MonoBehaviour
{
    public bool Alarm;
    private GameObject Prison_Door;
    private GameObject Current_Door;
    private Vector3 Changed_Pos;
    void Start()
    {
        Prison_Door = GameObject.Find("Sliding_Door");

        Changed_Pos = Prison_Door.transform.position;

        //Alarm = false;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Prison_Door);
    }

    // Update is called once per frame
    void Update()
    {
        Current_Door = GameObject.Find("Sliding_Door");

        if(Changed_Pos == Current_Door.transform.position)
        {
            Debug.Log("Is closed");
            Alarm = false;
        }

        if(Changed_Pos != Current_Door.transform.position)
        {
            Debug.Log("Is opened");
            Alarm = true;
        }

    }
}
