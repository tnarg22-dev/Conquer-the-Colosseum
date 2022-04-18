using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject spawnPoint5;
    public GameObject spawnPoint6;
    public GameObject spawnPoint7;
    public GameObject spawnPoint8;
    public GameObject Enemy;
    public bool enemiesAlive;
    public int currentMaxSpawn = 1;



    void Start()
    {
      
    }



    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            enemiesAlive = false;
            currentMaxSpawn = currentMaxSpawn + 1;
            StartCoroutine(WavespawnEnemies());
        }
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            enemiesAlive = true;
        }

   }
    IEnumerator WavespawnEnemies()
    {
        Debug.Log("started Spawning");
        for (int i = 0; i < currentMaxSpawn; i++)
        {
            AllSpawn();
       
        yield return new WaitForSeconds(1);
            

        }

    }
 
    public void AllSpawn()
    {
       Instantiate(Enemy,spawnPoint1.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint2.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint3.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint4.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint5.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint6.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint7.transform.position, Quaternion.identity);
       Instantiate(Enemy,spawnPoint8.transform.position, Quaternion.identity);
    }
}
