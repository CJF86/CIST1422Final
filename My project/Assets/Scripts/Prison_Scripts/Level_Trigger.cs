using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Component[] Clothes_Array;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Aemond" || collision.gameObject.tag == "Jace" || collision.gameObject.tag == "Luke")
        {

            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            Clothes_Array = collision.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach(SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }

            Debug.Log(collision.gameObject.name + "escaped");
        }
    }
}
