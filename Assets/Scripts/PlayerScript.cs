using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Sarah - delete two lines if not working
    public GameObject player;
    public float turnspeed=180f;
    
    private float xPos = 0, zPos = 0;
    public float speed = .05f;
    public float clamp = 1;
    private CharacterController _controller;
    private int lunchId = 5;
    public int lunchesDelivered;
    public int totalLunches;

    public AudioSource footsteps;

    public GameObject TaskManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //movement
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     xPos -= speed * Time.deltaTime;

        // }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     xPos += speed * Time.deltaTime;
        // }

        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     zPos += speed * Time.deltaTime;
        // }

        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     zPos -= speed * Time.deltaTime;
        // }
        //transform.localPosition = new Vector3(xPos, 0, zPos);
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(moveX, 0f, moveY);

        move = Vector3.ClampMagnitude(move, clamp) * Time.deltaTime;
        _controller.Move(move);

        // Sense if the player is moving, and if yes, play footsteps
        if (_controller.velocity.x != 0 || _controller.velocity.z != 0) {
            //if player moving, rotate in direction of movement
            //he pitches forward when he's still and idk how to change that at the moment
            player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.LookRotation (move), turnspeed * Time.deltaTime);
            if (!footsteps.isPlaying) {
                footsteps.Play();
            }
        } else {
            footsteps.Stop();
        }

       this.transform.position = new Vector3(transform.position.x, -323.0371f ,transform.position.z);
        
        //Sarah - player rotation
        //need to make sure rotation stops when not moving
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "NPC" && TaskManager != null)
        {
            Debug.Log("Collide with NPC");
            foreach (Task t in TaskManager.GetComponent<TaskManagerScript>().playerTasks)
            {
                if (t.taskId == lunchId)
                {
                    //increment
                    Debug.Log("increment");
                    lunchesDelivered++;
                    t.taskDesc = $"Deliver lunches to NPCs {lunchesDelivered}/{totalLunches}";
                    if(lunchesDelivered == totalLunches)
                    {
                        //complete task
                        //CompleteTaskScript.C.completeTask(TaskManager, lunchId);
                        TaskManager.GetComponent<TaskManagerScript>().completeTask(lunchId);
                    }
                    break;
                }
            }
        }
    }


    private void multipleTask(int endVal)
    {

    }
}
