using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Trash_Collection : MonoBehaviour
{
    private GameObject Evidence;
    private GameObject Alarm;
    private GameObject Door;
    private GameObject[] Luke_Array;
    private GameObject[] Jace_Array;
    private GameObject[] Aemond_Array;
    private GameObject[] Spawner_Array;
    private List<GameObject> Luke_List;
    private List<GameObject> Aemond_List;
    private List<GameObject> Jace_List;
    private List<GameObject> Spawner_List;
    void Start()
    {
        Evidence = GameObject.Find("Collected_Evidence");
        Alarm = GameObject.Find("AlarmTrigger");
        Door = GameObject.Find("Sliding_Door");
        Aemond_Array = GameObject.FindGameObjectsWithTag("Aemond");
        Jace_Array = GameObject.FindGameObjectsWithTag("Jace");
        Luke_Array = GameObject.FindGameObjectsWithTag("Luke");
        Spawner_Array = GameObject.FindGameObjectsWithTag("Prisoner_Tracking");

        Luke_List = Luke_Array.ToList();
        Aemond_List = Aemond_Array.ToList();
        Jace_List = Jace_Array.ToList();
        Spawner_List = Spawner_Array.ToList();

        foreach (GameObject go in Luke_List)
        {
            Destroy(go);
        }

        foreach (GameObject go in Jace_List)
        {
            Destroy(go);
        }

        foreach (GameObject go in Aemond_List)
        {
            Destroy(go);
        }

        foreach(GameObject go in Spawner_List)
        {
            Destroy(go);
        }

        Destroy(Alarm);
        Destroy(Evidence);
        Destroy(Door);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
