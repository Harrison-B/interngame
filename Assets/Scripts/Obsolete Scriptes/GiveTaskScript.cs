using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class GiveTaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TaskManager;

    public string taskStatus;

    public string taskDesc;

    public int taskID;

    public int taskScore;

    public GameObject taskTarget;
    public GameObject taskTargetStatic;
    public int taskTimer;

    //public static GiveTaskScript G;

    private bool inList;
    public static bool newTask = false;


    void Start()
    {
        //G = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && TaskManager != null) {
            //Task tempTask = new Task(taskID, taskStatus, taskDesc, taskScore, taskTarget, taskTargetStatic, taskTimer);

            //giveTask(tempTask);
            //TaskManager.GetComponent<TaskManagerScript>().giveTask(tempTask);

           // Task tempTask = new Task(taskID, taskStatus, taskDesc); 
           // TaskManager.GetComponent<TaskManagerScript>().playerTasks.Add(tempTask);
        }
    }

    // public void giveTask(Task tempTask)
    // {
    //     inList = TaskManager.GetComponent<TaskManagerScript>().taskInList(taskID);
    //     if (!inList)
    //     {
    //         TaskManager.GetComponent<TaskManagerScript>().playerTasks.Add(tempTask);
    //         newTask = true;
    //         Debug.Log("New task");

    //         //GetComponent<NotificationScript>();
    //         //NotificationScript.addExclamation(tempTask);
    //     } 
    // }

    public bool newTaskCheck()
    {
        return newTask;
    }
}
