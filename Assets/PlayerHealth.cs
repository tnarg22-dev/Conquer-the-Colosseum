using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerHp = 100;
    public Animator Animator;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public GameObject health6;
    public GameObject health7;
    public GameObject health8;
    public GameObject health9;
    public GameObject health10;
    public GameObject deathoverlay;
    public GameObject explosion;
    public bool isdead = false;
    
    public float deathtimer = 2f;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
        
        
        playerDeath();
        if(PlayerHp <= 90)
        {
            health10.SetActive(false);
        }
        if(PlayerHp <= 80)
        {
            health9.SetActive(false);
        }
        if(PlayerHp <= 70)
        {
            health8.SetActive(false);
        }
        if(PlayerHp <= 60)
        {
            health7.SetActive(false);
        }
        if(PlayerHp <= 50)
        {
            health6.SetActive(false);
        }
        if(PlayerHp <= 40)
        {
            health5.SetActive(false);
        }
        if(PlayerHp <= 30)
        {
            health4.SetActive(false);
        } 
        if(PlayerHp <= 20)
        {
            health3.SetActive(false);
        }
        if(PlayerHp <= 10)
        {
            health2.SetActive(false);
        }        
        if(PlayerHp <= 0)
        {
            health1.SetActive(false);
        }
       
       
    }
    void playerDeath()
    {
        if(PlayerHp <= 0)
        {
           deathoverlay.SetActive(true);
            Destroy(this.gameObject);   
            
        }
    }

    
}
