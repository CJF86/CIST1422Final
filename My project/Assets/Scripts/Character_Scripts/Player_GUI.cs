using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player_GUI : MonoBehaviour
{
    public Player_Health Current_Health;

    public GameObject Player;

    public TextMeshProUGUI Health_Text;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player.name);
        Health_Text = GetComponent<TextMeshProUGUI>();

        Current_Health = Player.GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Health_Text.text = "Health: " + Current_Health.Total_Health.ToString();
    }
}
