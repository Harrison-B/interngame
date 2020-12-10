using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingScript : MonoBehaviour
{
    public int taskToComplete;
    public int taskToGive;

    public bool processStarted;
    public bool processFinished;

    public GameObject TaskManager, pendingNotification, taskNotification;

    // public string taskStatus;
    // public string taskDesc;
    // public int taskScore;
    // public GameObject taskTarget;
    // public GameObject taskTargetStatic;
    // public int taskTimer;

    // Start is called before the first frame update
    void Start()
    {
        processStarted = false;
        processFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !processStarted) {

        }
        
        if (other.gameObject.tag == "Player" && TaskManager != null && !processStarted)
        {
            //check if has task then start process
            //Debug.Log("Player Collided check for task");
            foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
            {
                //Debug.Log(t.taskId);
                if (t.taskId == taskToComplete)
                {
                    //Debug.Log("Check worked");
                    StartCoroutine(startProcess());
                    break;
                }
            }
        }
        if (other.gameObject.tag == "Player" && TaskManager != null && processFinished)
        {

            //Debug.Log("GUILLITINE: Give task = " + taskToGive);
            TaskManager.GetComponent<TaskManagerScript>().updateTask(taskToComplete, taskToGive);

            processFinished = false;
            processStarted = false;
        }
    }



    private IEnumerator startProcess()
    {
        Debug.Log("Process started");
        processStarted = true;
        foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
        {
            if (t.taskId == taskToComplete)
            {
                Debug.Log("Change to brewing");
                t.taskDesc = "Brewing...";
                Destroy(t.taskNotif);
                GameObject tempNotif = Instantiate(pendingNotification, new Vector3(t.taskTarget.transform.position.x, -280, t.taskTarget.transform.position.z), pendingNotification.transform.rotation);
                t.taskNotif = tempNotif;
                break;
            }
        }
        yield return new WaitForSeconds(5);
        processFinished = true;
        Debug.Log("Process Finished");
        //change task description to collect coffee
        foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
        {
            if (t.taskId == taskToComplete)
            {
                Debug.Log("Change to get coffee");
                t.taskDesc = "Get coffee";
                Destroy(t.taskNotif);
                GameObject tempNotif2 = Instantiate(taskNotification, new Vector3(t.taskTarget.transform.position.x, -280, t.taskTarget.transform.position.z), taskNotification.transform.rotation);
                t.taskNotif = tempNotif2;
                break;
            }
        }
    }
}
