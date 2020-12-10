using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossScript : MonoBehaviour
{

    public float speed = .05f;
    private GameObject targetObj, taskManager;
    private Transform target;
    private int selectTarget;
    private GameObject[] toBreak;
    public int chance, delay, rate;
    //targetExists prevent unnecessary functions from running (will boss break which would interrupt find target)
    private bool targetExists = false;
    public AudioSource laugh;

    private NavMeshAgent nav;
   // private int destPoint;

    //TODO: Give boss home base to return to?? 
    //TODO: Figure out how to go around objects

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        InvokeRepeating("WillBossBreak", delay, rate);
    }

    // Update is called once per frame
    void Update()
    {

        if (targetExists)
        {
            nav.destination = target.position;
           // destPoint = (destPoint + 1) % points.Length;

            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        //on collision with breakable object -> make it break
        //TODO: Have it take some time?? 
        if (other.gameObject.tag == "Breakable")
        {
            other.gameObject.transform.tag = "Broken";
            targetExists = false;
            laugh.Play();
        }
    }

    private void FindTarget()
    {
        //Finds all breakable objects and randomly targets one
        targetExists = true;
        toBreak = GameObject.FindGameObjectsWithTag("Breakable");

        if(toBreak.Length > 0)
        {
            selectTarget = Random.Range(0, toBreak.Length);

            targetObj = toBreak[selectTarget];

            target = targetObj.transform;
        }

    }

    private void WillBossBreak()
    {
        //determines the odds of the boss going to break things
        if (!targetExists)
        {
            int i = Random.Range(0, 100);

            if (i > chance)
            {
                FindTarget();
            }
            Debug.Log("Will Boss Break");
        }

    }
}
