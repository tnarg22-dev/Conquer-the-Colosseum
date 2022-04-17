using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    public GameObject explosionpoint;
    public GameObject player;
    int layerMask = 1 << 8;
    public int speed = 4;
    public int maxspeed = 4;
    public int walkspeed = 2;
    public bool isMoving = true;
    public Animator EnemyAnimator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!isMoving)
        {
            EnemyAnimator.SetBool("Attack", true);
            EnemyAnimator.SetBool("Moving", false);
        }
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 targetDirection = player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            EnemyAnimator.SetBool("Moving", true);
            

        }
    
        MovementChecker();


       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(explosion,explosionpoint.transform);
        }
    }
    public void MovementChecker()
        {
        RaycastHit hit;
            Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 2f, layerMask);
                if (hit.collider == null)
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            isMoving = true;



        }

                if (hit.collider != null)
        {
            isMoving = false;
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
 
        }


        RaycastHit CloseCheck;
           Physics.Raycast(transform.position, player.transform.position - transform.position, out CloseCheck, 5f, layerMask);
            if(CloseCheck.collider == null)
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            EnemyAnimator.SetBool("CloseToPlayer", false);
            speed = maxspeed;

        }

            if(CloseCheck.collider != null)
        {
 
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            EnemyAnimator.SetBool("CloseToPlayer", true);
            speed = walkspeed;
        }

        }
       
        
}
