using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Link : MonoBehaviour
{
    public Transform Player_Eyes;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Eyes = GameObject.Find("Man_Eyes_Mesh").transform;

        transform.position = Player_Eyes.transform.position;
        
    }
}
