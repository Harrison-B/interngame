using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static HighScoreManager GMInstance;

    public int currentScore;
    public int highScore;
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

    public void updateHighScore (int newscore) {
        currentScore = newscore;
        if (newscore > highScore ) {
            highScore = newscore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver") {
            
            Text scoreText = GameObject.FindGameObjectWithTag("scoretext").GetComponent<Text>();
            scoreText.text = currentScore.ToString();

            Text hScoreText = GameObject.FindGameObjectWithTag("highscoretext").GetComponent<Text>();
            hScoreText.text = highScore.ToString();


            Text firedText = GameObject.FindGameObjectWithTag("firedtext").GetComponent<Text>();

            if (currentScore <= 99)
            {
                //you're fired
                firedText.text = "SCORE UNDER 100, YOU ARE FIRED!";
            } else if (currentScore > 99 && currentScore <= 150)
            {
                //good work
                firedText.text = "SCORE ABOVE 100 BUT YOU COULD IMPROVE";
            } else if (currentScore > 150) {
                firedText.text = "SCORE ABOVE 150, THE BOSS IS HAPPY :)";
            }
        }
    }
}
