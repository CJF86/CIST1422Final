using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Link : MonoBehaviour
{
    public Transform Camera_Container;
    // Start is called before the first frame update
    void Start()
    {
        Camera_Container = GameObject.Find("Camera_Pos").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera_Container.transform.position;
        
    }
}
