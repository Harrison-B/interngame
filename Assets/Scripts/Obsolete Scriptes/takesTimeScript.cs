using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takesTimeScript : MonoBehaviour
{
    //private bool active = false;
    public GameObject TaskManager;

    public int taskID;


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
        // if (gameObject.tag == "Active")
        // {

        //     //check if player is colliding to control timer
        //     if (isPlayerColliding == true)
        //     {
        //         timerTemp -= Time.deltaTime;
        //         if (timerTemp < 0)
        //         {
        //             timerTemp = 0;
        //         }
        //     }
        // }


    }

    void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag == "Player" && gameObject.tag == "Active")
        // {
        //     Debug.Log("Player collide enter");
        //     //GiveTaskScript.G.giveTask(taskID, taskStatus, taskDesc, taskScore, taskTarget, taskTimer);
        //     isPlayerColliding = true;
        // }
    }

    void OnCollisionStay(Collision other)
    {
        // if (other.gameObject.tag == "Player" && isPlayerColliding == true && gameObject.tag == "Active")
        // {
        //     Debug.Log("Countdown not done yet");
        //     if (timerTemp <= 0)
        //     {
        //         //complete task
        //         Debug.Log("Complete Task");
        //         //CompleteTaskScript.C.completeTask(TaskManager, taskID);
        //         TaskManager.GetComponent<TaskManagerScript>().completeTask(taskID);
        //         gameObject.transform.tag = "InActive";

        //     }

        // }
    }

    // If the player is not colliding reset our timer
    void OnCollisionExit(Collision other)
    {
        // if (other.gameObject.tag == "Player")
        // {
        //     Debug.Log("Player exit");
        //     isPlayerColliding = false;
        //     timerTemp = timerCountDown;
        // }
    }
}
