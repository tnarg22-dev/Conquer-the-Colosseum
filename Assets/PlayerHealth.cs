using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerHp = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDeath();
    }
    void playerDeath()
    {
        if(PlayerHp <= 0)
        {
            Destroy(this.gameObject);   
        }
    }
}
