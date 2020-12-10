using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioScript : MonoBehaviour
{
    
    private static UIAudioScript GMInstance;
    void Awake(){
        DontDestroyOnLoad (this);
            
        if (GMInstance == null) {
            GMInstance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
