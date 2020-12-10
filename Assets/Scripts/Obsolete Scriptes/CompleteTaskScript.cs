using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TaskManager;
    public int taskToComplete;
    public GameObject GameManager;
    public static bool complete = false;
    //public static CompleteTaskScript C;

    public GameObject completeNotification;



    void Start()
    {
        //C = this;

        if (taskToComplete == 0) {
            Debug.Log("A task completion object does not have a taskId assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
         if (other.gameObject.tag == "Player" && TaskManager != null) {
           //TaskManager.GetComponent<TaskManagerScript>().completeTask(taskToComplete);

        }
    }

    public void checkForItem(string reqItem, int taskToComplete)
    {
        if (reqItem == "")
        {
            //TaskManager.GetComponent<TaskManagerScript>().completeTask(taskToComplete);
        }
        else
        {

        }
    }
   
    // MOVED TO TASK MANAGER SCRIPT
    // public void completeTask(GameObject TaskManager, int taskToMarkCompleted)
    // {
    //     foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
    //     {
    //         if (t.taskId == taskToMarkCompleted)
    //         {
    //             GameManager.GetComponent<GameManagerScript>().updateScore(t.taskScore);
    //             TaskManager.GetComponent<TaskManagerScript>().playerTasks.Remove(t);

    //             Transform parentObject = t.taskTarget.transform.parent;
    //             GameObject tempNotif = Instantiate(completeNotification, new Vector3(t.taskTarget.transform.position.x, -300, t.taskTarget.transform.position.z), completeNotification.transform.rotation, parentObject.transform);
    //             Destroy(tempNotif, 2);

    //             break;
    //         }
    //     }
    // }

    public bool completeTaskCheck()
    {
        return complete;
    }
}
