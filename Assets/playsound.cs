using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource swing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetButton("Attack 1"))
        {
            swing.Play();
            Debug.Log("soundPlayed");
        }   
    }
    
}
