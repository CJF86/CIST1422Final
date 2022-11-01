using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Link : MonoBehaviour
{
    public Transform Player_Eyes;
    // Start is called before the first frame update
    void Start()
    {
        Player_Eyes = GameObject.Find("Man_Eyes_Mesh").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player_Eyes.transform.position;
        
    }
}
