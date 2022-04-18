using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    int layerMask = 1>>6;
    public int speed = 4;
    public int maxspeed = 4;
    public int walkspeed = 2;
    public bool isMoving = true;
    public Animator EnemyAnimator;
    public float countDown = 0.5f;
    public float maxtime = 0.5f;
    public int health = 10;
    [SerializeField] private GameObject gethealthsystemobject;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
      if(health <= 0)
        {
            isMoving = false;
            EnemyAnimator.SetTrigger("dead");
            Destroy(this.gameObject, 3);

        }

    }
   void FixedUpdate()
    {
          if (isMoving == false)
        {
            EnemyAnimator.SetBool("Attacking", true);
            EnemyAnimator.SetBool("Moving", false);
        }
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 targetDirection = player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            EnemyAnimator.SetBool("Moving", true);


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isMoving = false;

        }
        if(other.gameObject.tag == "PlayerWeapon")
        {
            EnemyAnimator.SetTrigger("hit");
            health = health - 5;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isMoving = true;

        }
    }


}
