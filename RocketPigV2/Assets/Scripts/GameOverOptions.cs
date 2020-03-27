using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using CloudOnce;

public class GameOverOptions : MonoBehaviour
{
    public Canvas gameoverCanvas;
    public Canvas mainCanvas;
    public Canvas overlayCanvas;
    public Text gameOverComment;
    public TextMeshProUGUI scoreFinal;
    public TextMeshProUGUI bestScore;

    // Use this for initialization
    void Awake()
    {


    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (RocketPig.die)
        {
            //enable gameover canvas
            StartCoroutine(enableGameOverCanvas(0.5f));
            if (RocketPig.diedByCollision)
            {
                gameOverComment.text = "WATCH OUT FOR COMETS!";
            }
            else
            {
                gameOverComment.text = "YOU RAN OUT OF FUEL!";
            }
			int totalScore = (int)PlayGameScene.totalScoreFinal;
            if (totalScore > PlayerPrefs.GetInt("highscore2"))
            {
                PlayerPrefs.SetInt("highscore2", totalScore);
                Leaderboards.RocketPigHighScore.SubmitScore(totalScore);
            }
			bestScore.text = PlayerPrefs.GetInt("highscore2").ToString("00");
            scoreFinal.text = totalScore.ToString("00");
        }
    }


    IEnumerator enableGameOverCanvas(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameoverCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
        overlayCanvas.gameObject.SetActive(false);
        PlayPageOptions.normalMainMusic();

    }

    public void restartOnClick()
    {
        PlayPageOptions.playClick1Sound();
        SceneManager.LoadScene("LaunchScene");
        RocketPig.die = false;
        PlayGameScene.blastOffTriggered = false;
    }



    public void backToMainMenuOnClick()
    {
        SceneManager.LoadScene("Main menu");
        RocketPig.die = false;
        Time.timeScale = 1;

    }

}
