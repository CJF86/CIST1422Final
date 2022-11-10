using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Opening : MonoBehaviour
{

    public Transform Sliding_Door;

    public GameObject Player;

    public Light Warning_Light;

    float duration = 1.0f;

    public bool Door_Movement;

    void Start()
    {
        Sliding_Door = GameObject.Find("Sliding_Door").transform;

        Player = GameObject.FindGameObjectWithTag("Player");

        Warning_Light = GameObject.FindGameObjectWithTag("Wall_Light").GetComponent<Light>();

        Debug.Log(Warning_Light.name);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)==true)
        {
            Debug.Log("Door is sliding");
            Door_Movement = true;
            
        }
    }

    public void Door_Open()
    {
        Sliding_Door.transform.Translate(0f, 0f, 10f);
    }

    public void Light_Flicker()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        Warning_Light.color = Color.Lerp(Color.white, Color.red, t);
    }
}
