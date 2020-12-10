using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableScript : MonoBehaviour
{

    //private bool active = false;
    public GameObject warning;
    public GameObject TaskManager;

    public int taskID;
    public int nextTask;
    // public int taskScore;
    // public GameObject taskTarget;
    // public GameObject taskTargetStatic;
    // public int taskTimer;
    // public string taskStatus;
    // public string taskDesc;


    private bool isPlayerColliding;
    public float timerCountDown = 5.0f;
    private float timerTemp;

    // Start is called before the first frame update
    void Start()
    {
        timerTemp = timerCountDown;
    }

    // Update is called once per frame
    void Update()
    {
        /* if(gameObject.tag == "Broken")
        {
            //only calls when initially turned broken using active to control
            //instantiates alert to player that something is broken by creating a red signal box
            if (!active)
            {
                Instantiate(warning, new Vector3(transform.position.x, 15, transform.position.z), Quaternion.identity);
                active = true;
            }

            //check if player is colliding to control timer
            if (isPlayerColliding == true)
            {
                timerTemp -= Time.deltaTime;
                if (timerTemp < 0)
                {
                    timerTemp = 0;
                }
            }
        } */


    }
    /*
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Broken")
        {
            Debug.Log("Player collide enter");

            //Task tempTask = new Task(taskID, taskStatus, taskDesc, taskScore, taskTarget, taskTargetStatic, taskTimer);
            //GiveTaskScript.G.giveTask(tempTask);
            //TaskManager.GetComponent<TaskManagerScript>().giveTask(tempTask);
            isPlayerColliding = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && isPlayerColliding == true)
        {
            Debug.Log("Countdown not done yet");
            if (timerTemp <= 0)
            {
                //complete task
                Debug.Log("Complete Task");
                //TaskManager.GetComponent<TaskManagerScript>().completeTask(taskID);

                TaskManager.GetComponent<TaskManagerScript>().updateTask(taskID, nextTask);
                gameObject.transform.tag = "Breakable";

            }

        }
    }

    // If the player is not colliding reset our timer
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player exit");
            isPlayerColliding = false;
            timerTemp = timerCountDown;
        }
    } */
}
