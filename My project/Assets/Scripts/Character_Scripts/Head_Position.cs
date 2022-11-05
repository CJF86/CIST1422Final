using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Position : MonoBehaviour
{
    public GameObject Head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Head = GameObject.Find("Camera_Pos");

        Head.transform.position = transform.position;
    }
}
