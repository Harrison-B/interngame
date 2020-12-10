using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public bool needsFavor;

    // public string taskStatus;
    // public string taskDesc;

    // public int taskID;
    // public int taskScore;
    // public GameObject taskTarget;
    // public GameObject taskTargetStatic;
    // public int taskTimer;
    // public int taskSteps;

    // Task ID of favor
    public int assignTaskId;
    public GameObject TaskManager;

    //3 is coffee task
    private int finishID = 3;
    private bool hasCoffeeTask;


    public int chance, delay, rate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NPCNeedsFavor", delay, rate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NPCNeedsFavor()
    {
        if (!needsFavor)
        {
            int i = Random.Range(0, 100);

            if (i > chance)
            {
                RequestPlayer();
            }
        }
    }

    private void RequestPlayer()
    {
        needsFavor = true;
        Debug.Log("Needs favor = true");
        //Activate UI signal for player
    }

    void OnCollisionEnter(Collision other)
    {
        foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
        {
            if (t.taskId == finishID)
            {
                hasCoffeeTask = true;
                break;
            }
        }
        if (other.gameObject.tag == "Player" && hasCoffeeTask)
        {
            Debug.Log("FinishTask");
            //CompleteTaskScript.C.completeTask(TaskManager, finishID);
            TaskManager.GetComponent<TaskManagerScript>().completeTask(finishID);
            needsFavor = false;
        }
        else if (other.gameObject.tag == "Player" && needsFavor)
        {
            Debug.Log("Gives Task");

            //Task tempTask = new Task(taskID, taskStatus, taskDesc, taskScore, taskTarget, taskTargetStatic, taskTimer, taskSteps);
            
            Task tempTask = TaskManager.GetComponent<TaskManagerScript>().allTasksList.Find(x=> x.taskId == assignTaskId);
            
            //GiveTaskScript.G.giveTask(tempTask);
            TaskManager.GetComponent<TaskManagerScript>().giveTask(tempTask);
        }
    }
}
