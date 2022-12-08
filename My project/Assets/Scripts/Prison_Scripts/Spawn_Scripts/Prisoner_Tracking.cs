using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner_Tracking : MonoBehaviour
{
    public List<GameObject> Prisoner_Array;

    public NPC_Health NPC_Health;
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //Prisoner_Array.Add(GameObject.FindGameObjectWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Prisoner_Array.Count; i++)
        {
            NPC_Health = Prisoner_Array[i].GetComponent<NPC_Health>();

            if(NPC_Health.Total_Health <= 0)
            {
                Prisoner_Array.RemoveAt(i);
            }
        }
    }
}
