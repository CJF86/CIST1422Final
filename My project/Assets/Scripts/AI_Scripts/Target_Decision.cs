using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Decision : MonoBehaviour
{
    public int Target_Choice;

    public bool Retarget;

    public Jace_Target jace_Targeting;

    public Luke_Target luke_Targeting;

    public Aemond_Target aemond_Targeting;

    public AI_Events Player_Targeting;

    public List<int> Script_Array = new List<int>();

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        Target_Choice = Random.Range(0,4);
        Debug.Log("This is the choice " + Target_Choice);
        jace_Targeting = gameObject.GetComponent<Jace_Target>();
        luke_Targeting = gameObject.GetComponent<Luke_Target>();
        aemond_Targeting = gameObject.GetComponent<Aemond_Target>();
        Player_Targeting = gameObject.GetComponent<AI_Events>();

        if(Target_Choice == 1)
        {
            luke_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[0]);
            
        }

        if(Target_Choice == 2)
        {
            
            jace_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[1]);
        }

        if(Target_Choice == 3)
        {
            aemond_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[2]);
        }

        if(Target_Choice == 4)
        {
            Player_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[3]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jace_Targeting.enabled == false && aemond_Targeting.enabled == false && Player_Targeting.enabled == false && luke_Targeting.enabled == false)
        {
            Debug.Log("Retargeting Currently");
            Targeting();
        }
        
        
        
    }

    public void Targeting()
    {
        //Random.InitState(Time.frameCount);

        Target_Choice = Random.Range(0,4);
        Debug.Log("Retargeting to " + Target_Choice);
        jace_Targeting = gameObject.GetComponent<Jace_Target>();
        luke_Targeting = gameObject.GetComponent<Luke_Target>();
        aemond_Targeting = gameObject.GetComponent<Aemond_Target>();
        Player_Targeting = gameObject.GetComponent<AI_Events>();

        if (Target_Choice == 1)
        {
            luke_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[0]);
        }

        if (Target_Choice == 2)
        {
            jace_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[1]);
        }

        if (Target_Choice == 3)
        {
            aemond_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[2]);
        }

        if (Target_Choice == 4)
        {
            Player_Targeting.enabled = true;
            //Script_Array.RemoveAt(Script_Array[3]);
        }
    }
}
