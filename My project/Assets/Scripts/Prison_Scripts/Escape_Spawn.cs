using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Escape_Spawn : MonoBehaviour
{
    public Engine_Spawn Prisoner_Count;
    public GameObject Prisoner;
    public List<GameObject> Prisoner_Array;
    public Component[] Clothes_Array;
    public NPC_Health NPC_Health;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Prisoner_Count = GameObject.Find("EngineSpawn").GetComponent<Engine_Spawn>();

        for (int i = 0; i < Prisoner_Count.Prisoner_Array.Count; i++)
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

    // Update is called once per frame
    void Update()
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
