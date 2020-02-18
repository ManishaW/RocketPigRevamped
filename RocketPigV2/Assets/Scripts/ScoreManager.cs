using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
	public static Text totalCounter;
     private int score = 5;
    // Start is called before the first frame update
    void Start()
    {
		totalCounter = GameObject.Find ("totalScoreFinal").GetComponent<Text> ();

        Cloud.OnInitializeComplete-=CloudOnceInitializeComplete;
        Cloud.Initialize(false,true);
    }

    // Update is called once per frame
    public void CloudOnceInitializeComplete()
    {
        Debug.LogWarning("Initialize");
    }
    public void ClickScore()
    {
        Debug.LogWarning("adding score to leaderboard");
        // score+=1;
        // scoreText.text=score.ToString();
        Leaderboards.RocketPigHighScore.SubmitScore(int.Parse(totalCounter.text));
    }
}
