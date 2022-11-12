using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] Enemy_Group;
    public GameObject Spawn_Zone;
    public RaycastHit Hit;
    public Vector3 Spawn_Position;
    public int Random_Element;
    //public Ray Check_Point;
    public bool Set_Point;
    // Start is called before the first frame update
    void Start()
    {
        Spawn_Zone = GameObject.FindGameObjectWithTag("Enemy_Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        for(int j = 0; j <= 5; j++)
        {
            Spawn_Point();

            if (Set_Point == true)
            {
                Debug.Log("Set point trigger");

                Random_Element = Random.Range(0, Enemy_Group.Length);

                Debug.Log("Spawning Enemy" + Enemy_Group[Random_Element]);

                Instantiate(Enemy_Group[Random_Element], Spawn_Position, transform.rotation);
            }
        }
        

        
        
    }

    public void Spawn_Point()
    {
        float RandomX = Random.Range(-20, 20);
        float RandomZ = Random.Range(-20, 20);

        Spawn_Position = new Vector3(transform.position.x + RandomX, 0, transform.position.z + RandomZ);

        if(Physics.Raycast(Spawn_Position,-Vector3.up,out Hit, 2.0f)&& Hit.transform.tag=="Enemy_Spawn")
        {
            Debug.Log("Point is set " + Set_Point);

            Set_Point = true;
        }
        

        

    }

}
