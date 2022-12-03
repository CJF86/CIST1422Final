using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Activation : MonoBehaviour
{
    private GameObject Player;
    private Camera Escape_Camera;
    private GameObject Camera_Holder;
    void Start()
    {
        Camera_Holder = GameObject.FindGameObjectWithTag("Escape_Ship");

        transform.position = new Vector3(Camera_Holder.transform.position.x+0.4f, Camera_Holder.transform.position.y+ 0.91739587f, Camera_Holder.transform.position.z);
        
    }

    private void Update()
    {
        transform.position = new Vector3(Camera_Holder.transform.position.x + 0.4f, Camera_Holder.transform.position.y + 0.91739587f, Camera_Holder.transform.position.z);
        transform.rotation = new Quaternion(Camera_Holder.transform.rotation.x, Camera_Holder.transform.rotation.y-Camera_Holder.transform.rotation.y, Camera_Holder.transform.rotation.z, Camera_Holder.transform.rotation.w);
    }


}
