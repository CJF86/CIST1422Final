using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Jace_Target : MonoBehaviour
{
    public Animator AI_Animator;

    private float Player_Sight_Range = 15f;

    private float Player_Attack_Range = 3f;

    public Transform Current_Player;

    public Vector3 AI_Destination;

    public RaycastHit Hit;

    public LayerMask Ground;

    public LayerMask Jace;

    [SerializeField]
    private bool Destination_Set = false;

    public bool In_Sight_Range;

    public bool In_Attack_Range;

    public float Point_Range = 10f;

    public NavMeshAgent AI_Agent;

    public Alarm_Trigger door_Opening;

    public Rigidbody AI_RigidBody;

    public bool Targeting;

    private string Escape_Trigger;

    void Start()
    {
        Debug.Log("Jace Script Enabled");

        AI_RigidBody = GetComponent<Rigidbody>();

        Current_Player = GameObject.FindGameObjectWithTag("Jace").transform;

        Debug.Log(Current_Player.name);
        AI_Animator = GetComponent<Animator>();

        AI_Agent = GetComponent<NavMeshAgent>();

        door_Opening = GameObject.Find("AlarmTrigger").GetComponent<Alarm_Trigger>();

        Escape_Trigger = PlayerPrefs.GetString("Escaped");

    }


    void Update()
    {
        Debug.Log("String value" + Escape_Trigger);

        In_Sight_Range = Physics.CheckSphere(transform.position, Player_Sight_Range, Jace);

        In_Attack_Range = Physics.CheckSphere(transform.position, Player_Attack_Range, Jace);

        if (Current_Player.gameObject.GetComponent<BoxCollider>().enabled == false)
        {
            gameObject.GetComponent<Jace_Target>().enabled = false;
            //Debug.Log("Jace Script Disabled");
        }

        In_Attack_Range = Physics.CheckSphere(transform.position, Player_Attack_Range, Jace);
        //Debug.Log("Can attack" + In_Attack_Range);
        In_Sight_Range = Physics.CheckSphere(transform.position, Player_Sight_Range, Jace);
        //Debug.Log("Can see" + In_Sight_Range);

        if (door_Opening.Alarm == true && Current_Player.gameObject.GetComponent<BoxCollider>().enabled == true)
        {
            Current_Player = GameObject.FindGameObjectWithTag("Jace").transform;

            

            if (In_Sight_Range == false && In_Attack_Range == false)
            {
                //AI_RigidBody.isKinematic = true;
                //Debug.Log("Patrol Trigger");
                Patrol_State();
            }

            if (In_Sight_Range == true && In_Attack_Range == false)
            {
                //AI_RigidBody.isKinematic = true;
                AI_Animator.SetBool("AI_Walking", false);
                AI_Animator.SetBool("AI_Attacking", false);
                //Debug.Log("Chase Trigger");
                Chase_State();
            }

            if (In_Attack_Range == true)
            {
                AI_RigidBody.isKinematic = false;
                AI_Animator.SetBool("AI_Walking", false);
                //Debug.Log("Attack Trigger");
                Attack_State();

            }
        }
        
    }

    public void Patrol_State()
    {
        AI_Animator.SetBool("AI_Running", false);
        AI_Animator.SetBool("AI_Attacking", false);
        float X_Point = Random.Range(-Point_Range, Point_Range);
        float Z_Point = Random.Range(-Point_Range, Point_Range);
        Vector3 Movement_Sum = transform.position - AI_Destination;

        if (Destination_Set == false)
        {
            AI_Destination = new Vector3(transform.position.x + X_Point, transform.position.y, transform.position.z + Z_Point);
        }

        if (Physics.Raycast(AI_Destination, -Vector3.up, 2.0f, Ground))
        {
            Destination_Set = true;
            //Debug.Log("Valid point");
            //Debug.Log("This is the "+Destination_Set);
            AI_Agent.SetDestination(AI_Destination);
        }

        if (Movement_Sum.magnitude <= 1f)
        {
            Destination_Set = false;
            AI_Animator.SetBool("AI_Walking", false);
            //Debug.Log("AI_Walking trigger false");
        }


        AI_Animator.SetBool("AI_Walking", true);
        


    }

    public void Chase_State()
    {

        //Debug.Log(Random_Targeting);
        AI_Animator.SetBool("AI_Running", true);
        AI_Agent.SetDestination(Current_Player.transform.position);
        //Debug.Log("Chasing");
        transform.LookAt(Current_Player);

    }

    public void Attack_State()
    {

        
        AI_Animator.SetBool("AI_Running", false);
        AI_Animator.SetBool("AI_Attacking", true);
        transform.LookAt(Current_Player);
        //Debug.Log("Attacking");

    }

    public bool Target_Switch()
    {
        if (Current_Player is null)
        {

            Targeting = true;
            return Targeting;

        }
        Targeting = true;
        return Targeting;

    }
}
