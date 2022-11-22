using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner_Spawn : MonoBehaviour
{
    public Prisoner_Tracking Prisoner_Count;
    public GameObject Prisoner;
    public List<GameObject> Prisoner_Array;
    public Component[] Clothes_Array;
    void Start()
    {
        Prisoner_Count = GameObject.Find("Prisoner_Tracking").GetComponent<Prisoner_Tracking>();

        for(int i = 0; i < Prisoner_Count.Prisoner_Array.Count; i++)
        {
            Prisoner = Instantiate(Prisoner_Count.Prisoner_Array[i], transform.position, Quaternion.identity) as GameObject;
            Clothes_Array = Prisoner.GetComponentsInChildren<SkinnedMeshRenderer>();
            Prisoner_Array.Add(Prisoner);
            foreach (SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = true;
            }

            Prisoner.GetComponent<NPC_Escape>().enabled = true;
            Prisoner.GetComponent<BoxCollider>().enabled = true;
        }
    }

    
}
