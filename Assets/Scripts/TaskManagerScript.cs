using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class Task {
    public int taskId;
    public string taskStatus;
    public string taskDesc;
    public int taskScore;
    //use static for noti script
    public GameObject taskTarget;
    public static GameObject taskTargetStatic;
    public int taskTimer;

    public int steps;

    public int currentStep;

    public GameObject taskNotif;

    public Task(int id, string status, string desc, int score, GameObject targetObject, GameObject targetStatic, int timeLimit, int stepsNum) {
        taskId = id;
        taskStatus = status;   
        taskDesc = desc;
        taskScore = score;
        taskTarget = targetObject;
        taskTargetStatic = targetStatic;
        taskTimer = timeLimit;
        steps = stepsNum;
        currentStep = 0;
    }

    public Task(int id, string status, string desc, int score, GameObject targetObject, GameObject targetStatic, int timeLimit) {
        taskId = id;
        taskStatus = status;   
        taskDesc = desc;
        taskScore = score;
        taskTarget = targetObject;
        taskTargetStatic = targetStatic;
        taskTimer = timeLimit;
        steps = 1;
        currentStep = 0;
    }
}

public class TaskManagerScript : MonoBehaviour
{
    public List<Task> playerTasks = new List<Task>();
    public Text uiTaskList;
    public float taskTime = 10f;
    public List<Task> allTasksList = new List<Task>();
    public GameObject coffeeMaker, copier, fridge, projector, sink, hrnpc, fileCabinet, blueNpc, coffeeNpc, toilet, printer, bossComp, conferenceNpc;

    Task[] allTasks = new Task[14];

    private bool inList;
    public static bool newTaskMan;

    public GameObject taskNotification, GameManager, completeNotification;

    [Header("Audio")]
    public AudioSource newTask;
    public AudioSource completedTask;

    //DELETE THIS LINE IF NOT WORKING


    private IEnumerator assignTasks;
    

    
        
    
    //TODO: Task Generator
    //Need program to add tasks throughout the game (timing function)
    //Needs random generator to select a task from the array
    //Need to start timer for the task (each one has it's own timer)
    //Remove / fail tasks when timer runs oout

    // Start is called before the first frame update
    void Start()
    {
        initializeList();
    
//SARAH - DELETE ALL IF NOT WORKING
    // - After 0 seconds, prints "Starting 0.0 seconds"
        // - After 0 seconds, prints "Coroutine started"
        // - After 5 seconds, prints "Coroutine ended: 5.0 seconds"
        print("Starting " + Time.time + " seconds");


        // Start function WaitAndPrint as a coroutine.

        assignTasks = WaitAndPrint(time: 5f);
        StartCoroutine(assignTasks);

        print("Sarah - Coroutine started");
    }

   
//SARAH - STOP  HERE


    // Update is called once per frame
    void Update()
    {
        uiTaskList.GetComponent<Text>().text = ListToText(playerTasks);
    }

    private string ListToText(List<Task> list)
    {
        string result = "";
        foreach(var listMember in list)
        {
            result += listMember.taskDesc.ToString() + "\n";
        }
        return result;
    }
     
     private IEnumerator WaitAndPrint(float time)
     {
         while (true)
         {
           
           //randomly gets value to represent task
           //range will need to be adjusted as more tasks are added
            var number = Random.Range(0, 7);
            //        playerTasks.Add(allTasks[0]);


            //checks if it exists in list
            //might want for loop to add a different task if it is in the list already.
            //I can do that easily enough - just let me know


            Task newTask = allTasks[number];
            giveTask(newTask);
            //Object original, Vector3 position, Quaternion rotation, Transform parent
            //Transform parentObject = allTasks[number].taskTarget.transform.parent;
            // MOVED TO GIVE TASK FUNCTION GameObject tempNotif = Instantiate(taskNotification, new Vector3(newTask.taskTarget.transform.position.x, -300, newTask.taskTarget.transform.position.z), taskNotification.transform.rotation);
            
            //Pairs the notification with the new task
            //newTask.taskNotif = tempNotif;
            //Destroy(tempNotif, 5);

            if (number == 4 || number == 6 || number == 3)
            {
                allTasks[number].taskTarget.tag = "Active";
            }
       
            //time check function (outside) - if time elapsed > a minute, taskTime = 4.5, <> 4, 

            yield return new WaitForSeconds(taskTime);

            print("Sarah - added task after " + Time.time + " seconds");

            //increase task generation by .25 seconds each time 
            taskTime -= .25f;
             
         }
         
     }


    //check for duplicate tasks
    public bool taskInList(int compareId)
    {
        foreach(Task listMember in playerTasks)
        {
            if(listMember.taskId == compareId)
            {
                return true;
            }
        }
        return false;
    }

    private void initializeList()
    {
        //Task(int id, string status, string desc, int score, gameobject, static gameobject, length)
        allTasks[0] = new Task(1, "In progress", "Deliver paper to copier", 15, copier, copier, 20);
        allTasks[1] = new Task(2, "In progress", "Brew coffee", 5, coffeeMaker, coffeeMaker, 20);
        allTasks[2] = new Task(10, "In progress", "Get lunches from fridge", 0, fridge, fridge, 20);
        allTasks[3] = new Task(6, "In progress", "Show a presentation", 15, projector, projector, 20);
        allTasks[4] = new Task(7, "In progress", "Unclog the sink", 15, sink, sink, 20);
        allTasks[5] = new Task(8, "In progress", "Get gift for NPC from HR", 0, hrnpc, hrnpc, 20);
        allTasks[6] = new Task(11, "In progress", "Alphabetize files", 15, fileCabinet, fileCabinet, 20);
        allTasks[7] = new Task(12, "In progress", "Deliver gift in dark blue", 20, blueNpc, blueNpc, 20);
        allTasks[8] = new Task(3, "In progress", "Deliver coffee", 15, coffeeNpc, coffeeNpc, 20);
        allTasks[9] = new Task(4, "In progress", "Fix Printer", 15, printer, printer, 20);
        allTasks[10] = new Task(5, "In progress", "Fix toilet", 25, toilet, toilet, 20);
        allTasks[11] = new Task(9, "In progress", "Fix Boss' computer", 25, bossComp, bossComp, 20);
        allTasks[12] = new Task(13, "In progress", "Bring lunch to the co-worker in the conference room", 20, conferenceNpc, conferenceNpc, 20, 2);
        allTasks[13] = new Task(14, "In progress", "Get coffee", 5, coffeeMaker, coffeeMaker, 20);

    }

    public void giveTask(Task tempTask)
    {
        inList = taskInList(tempTask.taskId);
        if (!inList)
        {
           playerTasks.Add(tempTask);
           //Debug.Log("New task");

            GameObject tempNotif = Instantiate(taskNotification, new Vector3(tempTask.taskTarget.transform.position.x, -280, tempTask.taskTarget.transform.position.z), taskNotification.transform.rotation);
            newTask.Play();
            //Pairs the notification with the new task
            tempTask.taskNotif = tempNotif;
        }
    }

    public void giveTaskByID(int id)
    {
        inList = taskInList(id);
        if (!inList)
        {
            foreach(Task t in allTasks)
            {
                if(t.taskId == id)
                {
                    Debug.Log("GUILLITINE: Got past 2nd if " + id + "Task desc: " + t.taskDesc);

                    playerTasks.Add(t);
                    //Debug.Log("New task");
                    GameObject tempNotif = Instantiate(taskNotification, new Vector3(t.taskTarget.transform.position.x, -280, t.taskTarget.transform.position.z), taskNotification.transform.rotation);
                    newTask.Play();
                    //Pairs the notification with the new task
                    t.taskNotif = tempNotif;
                }
            }
        }
    }

    public Task getTaskById(int id) {
        foreach(Task listMember in playerTasks)
        {
            if(listMember.taskId == id)
            {
                return listMember;
            }
        }
        return null;
    }

    public void completeTask(int taskToMarkCompleted)
    {
        foreach (Task t in playerTasks)
        {
            if (t.taskId == taskToMarkCompleted)
            {
                GameManager.GetComponent<GameManagerScript>().updateScore(t.taskScore);
                playerTasks.Remove(t);

                Destroy(t.taskNotif);
                //Transform parentObject = t.taskTarget.transform.parent;
                GameObject tempNotif = Instantiate(completeNotification, new Vector3(t.taskTarget.transform.position.x, -280, t.taskTarget.transform.position.z), completeNotification.transform.rotation);
                completedTask.Play();
                Destroy(tempNotif, 2);

                break;
            }
        }
    }

    //public void addExclamation(Task taskAdd)
    //{
    //    GameObject tempNotif = Instantiate(taskNotification, taskAdd.taskTargetStatic.transform);
    //    //GiveTaskScript.newTask = false;
    //    // StartCoroutine("WaitASec");
    //    //Destroy(tempNotif, 5);

    //}


    //Harrison Addition

    //This function is called by the TaskObjectScript to progress the status of tasks
    public void updateTask(int updatedTaskId, int nextTaskId) {
        // Loops through each active task

        foreach (Task t in playerTasks) {
            // Checks to see if task updated is an active task
            if (updatedTaskId == t.taskId) {
                if (nextTaskId == 0) {
                    completeTask(t.taskId);
                    break;
                } else if (updatedTaskId == nextTaskId && getTaskById(updatedTaskId).steps != getTaskById(updatedTaskId).currentStep) {
                    getTaskById(updatedTaskId).currentStep++;
                } else if (updatedTaskId == nextTaskId && getTaskById(updatedTaskId).steps == getTaskById(updatedTaskId).currentStep) {
                    completeTask(t.taskId);
                    break;
                } else {
                    giveTaskByID(nextTaskId);
                    completeTask(t.taskId);
                    break;
                }
            }
        }
    }



}