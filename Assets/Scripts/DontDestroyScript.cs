using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
   
    void Awake()
    {
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        // foreach (GameObject obj in objs) {
        //     if (obj != this.gameObject) {
        //         Destroy(obj);
        //     }
        // }

        // DontDestroyOnLoad(this.gameObject);
    }
}
