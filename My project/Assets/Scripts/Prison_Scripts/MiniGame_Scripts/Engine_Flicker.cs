using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Engine_Flicker : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Generator_Array;
    private List<GameObject> Generator_List;
    Transform[] allChildren;
    public Engine_Shutoff Shutoff_Valve;
    public Light_Flicker Light_Change;
    public bool ShutDown_Check;
    [SerializeField]
    public int Light_Trigger = 0;
    
    void Start()
    {
        ShutDown_Check = true;
        Generator_Array = GameObject.FindGameObjectsWithTag("Generator");
        Generator_List = Generator_Array.ToList();
        allChildren = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Light_Trigger <= 4)
        {
            Gen_Check();
        }
        
        

        


    }

    public void Gen_Check()
    {
        for(int i = 0; i  <Generator_List.Count; i++)
        {
            if(Generator_List[i].GetComponent<Animator>().enabled == false)
            {
                Light_Trigger++;
                Generator_List.Remove(Generator_List[i]);
            }
            else
            {
                Debug.Log(Generator_List[i].name + " is running");
            }
        }
    }
}
