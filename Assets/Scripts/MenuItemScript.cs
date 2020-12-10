using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class MenuItemScript : MonoBehaviour { // Extends the pointer handlers
 
    public string targetScene;
    public AudioSource click;

    private GameObject audioController;

    private AudioSource[] audioSources;

    void Start()
    {
        if (GameObject.Find("UIAudioController")) {
            audioController = GameObject.Find("UIAudioController");
            audioSources = audioController.GetComponents<AudioSource>();
            click = audioSources[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        //     SceneManager.LoadScene(targetScene);
    }

    public void LoadScene(string sceneName)
    {
        if (click) {
            PlayLoudClick();
        }

        SceneManager.LoadScene(sceneName);
    }

    public void PlaySoftClick() {
        click.volume = 0.3f;
        click.Play();
        click.volume = 1f;
    }
    public void PlayLoudClick() {
        click.Play();
    }

    public void QuitGame () {
        if (click) {
            PlayLoudClick();
        }
        Application.Quit ();
        Debug.Log("Game is exiting");
    }

}