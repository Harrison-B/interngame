using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskObjectScript : MonoBehaviour
{
    // This script is designed to be attatched to task related objects to either progress or complete the task. 
    // This script sends task updates to the TaskManager script which manages notifications and the active task list.
    
    public GameObject taskManager, gameManager; 
    public int taskId; //This is the reference to the task this object is associated with
    public int nextTaskId; // If there is another task in the sequence

    [Header("Button Mash Variables")]
    public bool requiresMash;
    public float mashCount;
    public float currentMashCount;
    public GameObject spacebarNotice;
    public Image spacebarProgress;

    [Header("Breakable Object Variables")]
    // These variables are only relevant for breakable objects
    public GameObject breakableObject;
    private bool isPlayerColliding = false;
    public float timerCountDown = 5.0f;
    private float timerTemp;
    private bool active = false;

    private bool playerTask = false;

    void Start()
    {
        if (!gameManager) {
            gameManager = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (breakableObject) {
            if (breakableObject.tag == "Broken" && active == false) {
                taskManager.GetComponent<TaskManagerScript>().giveTaskByID(taskId);
                active = true;
            }
        }

        if (taskManager.GetComponent<TaskManagerScript>().taskInList(taskId)) {
            playerTask = true;
        } else {
            playerTask = false;
        }


        //The below was moved from OnTriggerStay

        if (isPlayerColliding == true && requiresMash && playerTask)
        {
            spacebarProgress.fillAmount = currentMashCount / mashCount;
            // Debug.Log("Mash not done yet");
            if (Input.GetKeyUp(KeyCode.Space)) {
                currentMashCount++;
                // Debug.Log("Mash progress: " + currentMashCount / mashCount + "  Current mash count = " + currentMashCount);
            }
            
            if (currentMashCount > mashCount)
            {
                //complete task
                // Debug.Log("Complete Task");

                taskManager.GetComponent<TaskManagerScript>().updateTask(taskId, nextTaskId);
                spacebarNotice.SetActive(false);
                currentMashCount = 0;
                if (breakableObject) {
                    breakableObject.transform.tag = "Breakable";
                    active = false;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !requiresMash) {
            taskManager.GetComponent<TaskManagerScript>().updateTask(taskId, nextTaskId);
        } else if (other.gameObject.tag == "Player" && requiresMash && playerTask) {
            spacebarNotice.SetActive(true);
            spacebarProgress.fillAmount = currentMashCount / mashCount;
        }

        if (other.gameObject.tag == "Player")
        {
            isPlayerColliding = true; 
        }
    }



    void OnTriggerStay(Collider other)
    {
        
    }

    // If the player is not colliding reset our timer
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerTask)
        {
            //Debug.Log("Player exit");
            isPlayerColliding = false;
            spacebarNotice.SetActive(false);
            timerTemp = timerCountDown;
        }
    }


}
