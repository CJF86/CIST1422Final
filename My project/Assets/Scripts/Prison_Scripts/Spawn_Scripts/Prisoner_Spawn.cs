using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Prisoner_Spawn : MonoBehaviour
{
    public Prisoner_Tracking Prisoner_Count;
    public GameObject Prisoner;
    public List<GameObject> Prisoner_Array;
    public Component[] Clothes_Array;
    public NPC_Health NPC_Health;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
            Prisoner.GetComponent<BoxCollider>().enabled = true;
            Prisoner.GetComponent<NavMeshAgent>().enabled = true;
            Prisoner.GetComponent<NPC_Escape>().enabled = true;
            
            
        }
    }

    private void Update()
    {
        for (int i = 0; i < Prisoner_Array.Count; i++)
        {
            NPC_Health = Prisoner_Array[i].GetComponent<NPC_Health>();

            if (NPC_Health.Total_Health <= 0)
            {
                Prisoner_Array.RemoveAt(i);
            }
        }
    }


}
