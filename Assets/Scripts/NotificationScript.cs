using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taskNotification;
    public GameObject completetionNoti;
    
        

    void Start()
    {
        GetComponent<TaskManagerScript>();
        GetComponent<GiveTaskScript>();

        //Task t = new Task();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<GiveTaskScript>();
        if (GiveTaskScript.newTask == true || TaskManagerScript.newTaskMan == true)
        {
            // Debug.Log("Exclamation");
            // GameObject tempNotif = Instantiate(taskNotification, Task.taskTargetStatic.transform);
            // //GameObject tempNotif = Instantiate(taskNotification, new Vector3(Task.taskTargetStatic.transform.position.x, 15, transform.position.z), Quaternion.identity);
            // GiveTaskScript.newTask = false;
            // // StartCoroutine("WaitASec");
            // Destroy(tempNotif, 5);
        }
        GetComponent<CompleteTaskScript>();
        if (CompleteTaskScript.complete == true)
        {
            //int numChildren = Task.taskTargetStatic.transform.childCount;          
            //GameObject exclamationToDestroy = Task.taskTargetStatic.transform.GetChild(numChildren-1).gameObject;
            ////GameObject exclamationToDestroy = GetLastChidren(Task.taskTargetStatic.transform);
            //Destroy(exclamationToDestroy);
            //GameObject tempComplete = Instantiate(completetionNoti, Task.taskTargetStatic.transform);
            ////GameObject tempNotif = Instantiate(completetionNoti, new Vector3(Task.taskTargetStatic.transform.position.x, 15, transform.position.z), Quaternion.identity);
            ////StartCoroutine("WaitASec");
            //Destroy(tempComplete, 5);

            //CompleteTaskScript.complete = false;

        }

    }

    //public void addExclamation(Task taskAdd)
    //{
    //    GameObject tempNotif = Instantiate(taskNotification, taskAdd.taskTargetStatic.transform);
    //    //GiveTaskScript.newTask = false;
    //    // StartCoroutine("WaitASec");
    //    //Destroy(tempNotif, 5);

    //}


    //IEnumerator WaitASec()
    //{
    //    yield return new WaitForSeconds(2);
    //    DestroyImmediate(taskNotification, true);
    //    DestroyImmediate(completetionNoti, true);

    //}
}
