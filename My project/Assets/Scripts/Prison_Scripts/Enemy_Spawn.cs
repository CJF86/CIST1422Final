using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    //public GameObject[] Enemy_Group;
    public GameObject[] Spawn_Zone;
    public GameObject Enemy;
    public RaycastHit Hit;
    public Vector3 Spawn_Position;
    public int Random_Element;
    //public Ray Check_Point;
    public bool Set_Point;
    public bool Enemy_Loaded = false;
    [SerializeField]
    private int Enemies = 5;
    public GameObject[] Enemy_Array;
    public int Enemy_Select;
    // Start is called before the first frame update
    void Start()
    {
        Spawn_Zone = GameObject.FindGameObjectsWithTag("Enemy_Spawn");

        //Enemies = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn_Point();
        
        if(Spawn_Point()==true && Enemies > 0)
        {
            Spawn_Enemy();
            Enemies -= 1;
            Debug.Log(Enemies);
            
        }

       
        

        
        
    }

    public bool Spawn_Point()
    {
        float RandomX = Random.Range(-20, 20);
        float RandomZ = Random.Range(-20, 20);

        Spawn_Position = new Vector3(transform.position.x + RandomX, 0, transform.position.z + RandomZ);

        if(Physics.Raycast(Spawn_Position,-Vector3.up,out Hit, 2.0f)&& Hit.transform.tag=="Enemy_Spawn")
        {
            Debug.Log("Point is set " + Set_Point);

            Set_Point = true;
            return Set_Point;
        }
        else
        {
            Set_Point = false;
            return Set_Point;
        }
        
    }

    public void Spawn_Enemy()
    {
        Enemy_Select = Random.Range(0, Enemy_Array.Length);

        Enemy = Instantiate(Enemy_Array[Enemy_Select], Spawn_Position, Quaternion.identity) as GameObject;

    }

}
