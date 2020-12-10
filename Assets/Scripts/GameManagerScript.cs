using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public float gameLengthSeconds;
    public int score;
    public Text scoreText;
    public Text timerText;
    public Image LoadingBar;

    public GameObject highscoreManager;
    void Start()
    {
        StartCoroutine(reloadTimer(gameLengthSeconds));
        updateScore(0);
    }

    public float countDown;
    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = 0;
        countDown = reloadTimeInSeconds;

        while (counter < reloadTimeInSeconds)
        {
            counter += Time.deltaTime;
            countDown -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(countDown).ToString();
            yield return null;
        }
    }

    public void updateScore(int taskValue)
    {
        score += taskValue;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		LoadingBar.fillAmount = countDown / gameLengthSeconds;

        if (!scoreText) {
            scoreText = GameObject.FindGameObjectWithTag("scoretext").GetComponent<Text>();
            scoreText.text = score.ToString();
        }

        if (countDown < 0) {
            //Load new Scene
            highscoreManager = GameObject.FindGameObjectWithTag("highscoremanager");
            highscoreManager.GetComponent<HighScoreManager>().updateHighScore(score);
            
            SceneManager.LoadScene("GameOver");
        }
    }
}
