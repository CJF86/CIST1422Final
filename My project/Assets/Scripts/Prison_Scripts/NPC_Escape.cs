using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC_Escape : MonoBehaviour
{
    public GameObject Fuse_Trigger;
    public GameObject Escape_Point;
    public Animator NPC_Animation;
    public Door_Opening door_Opening;
    public NavMeshAgent NPC_Agent;
    // Start is called before the first frame update
    void Start()
    {
        NPC_Animation = GetComponent<Animator>();

        Escape_Point = GameObject.Find("Escape_Point");

        door_Opening = GameObject.Find("Fusebox 02").GetComponent<Door_Opening>();

        NPC_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door_Opening.Door_Movement == true)
        {
            Debug.Log("Escaping");
            NPC_Animation.SetBool("NPC_Trapped", false);
            NPC_Animation.SetBool("NPC_Escaped", true);
            NPC_Agent.SetDestination(Escape_Point.transform.position);
        }

        if(door_Opening.Door_Movement == false)
        {
            Debug.Log("Trapped");
            NPC_Animation.SetBool("NPC_Trapped", true);
            NPC_Animation.SetBool("NPC_Escaped", false);
            transform.LookAt(Escape_Point.transform);
        }

        
        
    }
}