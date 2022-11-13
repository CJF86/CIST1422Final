using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Sounds : MonoBehaviour
{
    public AudioSource Player_Audio;
    public AudioClip Walking_Sound;
    public AudioClip Attacking_Sound;
    // Start is called before the first frame update
    void Start()
    {
        Player_Audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk_Clips()
    {
        Player_Audio = GetComponent<AudioSource>();
        Player_Audio.PlayOneShot(Walking_Sound);
    }

    public void Attack_Sound()
    {
        Player_Audio = GetComponent<AudioSource>();
        Player_Audio.PlayOneShot(Attacking_Sound);
    }
}


