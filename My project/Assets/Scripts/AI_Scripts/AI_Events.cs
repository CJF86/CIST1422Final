using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script handles basic AI pathing and animations
public class AI_Events : MonoBehaviour
{
    public Animator AI_Animator;

    public float Player_Sight_Range = 15f;

    public float Player_Attack_Range = 5f;

    public Transform Current_Player;

    public Vector3 AI_Destination;

    public LayerMask Ground;

    public LayerMask Player;

    public bool Destination_Set = false;

    //public float Attack_Timing;

    //public bool Attack_Occurence;

    public bool In_Sight_Range;

    public bool In_Attack_Range;

    public float Point_Range = 10f;

    public NavMeshAgent AI_Agent;
    void Start()
    {
        Current_Player = GameObject.FindGameObjectWithTag("Player").transform;

        AI_Animator = GetComponent<Animator>();

        AI_Agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //RaycastHit Hit;

        Current_Player = GameObject.FindGameObjectWithTag("Player").transform;

       
        In_Attack_Range = Physics.CheckSphere(transform.position, Player_Attack_Range, Player);
        Debug.Log("Can attack" + In_Attack_Range);
        In_Sight_Range = Physics.CheckSphere(transform.position, Player_Sight_Range, Player);
        Debug.Log("Can see" + In_Sight_Range);


        if (In_Sight_Range==false && In_Attack_Range == false)
        {
            Debug.Log("Patrol Trigger");
            Patrol_State();
        }

        if(In_Sight_Range == true && In_Attack_Range == false)
        {
            AI_Animator.SetBool("AI_Walking", false);
            AI_Animator.SetBool("AI_Attacking", false);
            Debug.Log("Chase Trigger");
            Chase_State();
        }

        if(In_Attack_Range == true)
        {
            AI_Animator.SetBool("AI_Walking", false);
            Debug.Log("Attack Trigger");
            Attack_State();

        }

        
        

    }

    public void Patrol_State()
    {
        float X_Point = Random.Range(-Point_Range, Point_Range);
        float Z_Point = Random.Range(-Point_Range, Point_Range);
        Vector3 Movement_Sum = transform.position - AI_Destination;

        if(Destination_Set == false)
        {
            AI_Destination = new Vector3(transform.position.x + X_Point, transform.position.y, transform.position.z + Z_Point);
        }

        if (Physics.Raycast(AI_Destination, -Vector3.up,2.0f, Ground))
        {
            Destination_Set = true;
            Debug.Log("Valid point");
            Debug.Log("This is the "+Destination_Set);
        }

        if(Movement_Sum.magnitude <1f)
        {
            Destination_Set = false;
            AI_Animator.SetBool("AI_Walking", false);
            //Debug.Log("AI_Walking trigger false");
        }

        
        AI_Animator.SetBool("AI_Walking", true);
        AI_Agent.SetDestination(AI_Destination);

        
    }

    public void Chase_State()
    {
        AI_Animator.SetBool("AI_Running", true);
        AI_Agent.SetDestination(Current_Player.transform.position);
        Debug.Log("Chasing");
        
    }

    public void Attack_State()
    {
        AI_Animator.SetBool("AI_Running", false);
        AI_Animator.SetBool("AI_Attacking", true);
        
        Debug.Log("Attacking");
        
            
        
    }
}
