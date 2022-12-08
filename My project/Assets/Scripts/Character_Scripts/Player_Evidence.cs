using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player_Evidence : MonoBehaviour
{
    public Bird_Collection Current_Evidence;

    public GameObject Player_Data;

    public TextMeshProUGUI Bird_Text;
    void Start()
    {
        Player_Data = GameObject.Find("Collected_Evidence");
        Current_Evidence = Player_Data.GetComponent<Bird_Collection>();
        Bird_Text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Bird_Text.text = "Evidence found: " + Current_Evidence.Evidence_Collected.ToString();
    }
}
