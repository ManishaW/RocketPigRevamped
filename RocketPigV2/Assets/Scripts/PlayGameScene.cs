using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayGameScene : MonoBehaviour
{
    //declare variables
    public static float totalScoreFinal;
    public static float fuelCounter;
    public static float totalFuelAccumulated;

    public Button leftFinger;
    public Button rightFinger;
    public Text countdownText;
    public float CountdownTimer;
    public Text starCounterScore;
    public Text fuelCounterScore;
    public bool startCountdownTrigger;
    public static bool blastOffTriggered;
    public static float startTime;
    float countdownstarttime;
    float restseconds;
    public GameObject launchPad;
    public GameObject piggy;
    public GameObject background;

    Animator launchPadAnimator;
    Animator piggyAnimator;
    Animator backgroundAnimator;
    // Animator boltAnimator;
    public GameObject tutorialCanvas;
    // public GameObject bolts;

    void Awake (){
        launchPadAnimator = launchPad.GetComponent<Animator>();
        piggyAnimator = piggy.GetComponent<Animator>();
        backgroundAnimator= background.GetComponent<Animator>();
        
    }

    void Start()
    {
        //set objects
        leftFinger = GameObject.Find("leftFinger").GetComponent<Button>();
        rightFinger = GameObject.Find("rightFinger").GetComponent<Button>();
        countdownText = GameObject.Find("Countdown").GetComponent<Text>();
        fuelCounterScore = GameObject.Find("fuelCount").GetComponent<Text>();
        starCounterScore = GameObject.Find("starsScore").GetComponent<Text>();
        //to be reset each time game is played
        blastOffTriggered = false;
        totalScoreFinal = 0;
        fuelCounter = 0;
        CountdownTimer = 3; //starting integer for timer (easily changeable)
        startCountdownTrigger = false;
        Invoke("showTutorial", 0.5f);
        totalFuelAccumulated = 0;
    }
    void showTutorial(){
        if (PlayerPrefs.GetInt("tutorialStatus")==0){
          tutorialCanvas.SetActive(true);
          PlayPageOptions.playPopSound();
          PlayerPrefs.SetInt("tutorialStatus",1);
          Time.timeScale = 0;
        }
    }
    void timerMode()
    {
        float guitime = Time.time - countdownstarttime;
        restseconds = CountdownTimer - guitime;
        countdownText.text = Mathf.RoundToInt(restseconds).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (fuelCounter==1){
            PlayPageOptions.playZapTapSound();
        }
        //bolt animations
        if (fuelCounter>0 && !blastOffTriggered){
        }else if (fuelCounter>5){
        }else if (fuelCounter>10){
        }
        //update the scores 
        starCounterScore.text = ((int)totalScoreFinal).ToString("00");
        fuelCounterScore.text = (fuelCounter).ToString("00");
        //do the 3 second countdown timer
        if (CountdownTimer > 0 && startCountdownTrigger == true)
        {
            CountdownTimer = CountdownTimer - Time.deltaTime;
            string displayTime = CountdownTimer.ToString("0");
            countdownText.text = displayTime;
        }


        //countdown is 0 and pig is not flying yet
        if (countdownText.text.Equals("0") && blastOffTriggered == false )
        {
            countdownText.text = "BLAST OFF!";
            leftFinger.gameObject.SetActive(false);
            rightFinger.gameObject.SetActive(false);
            countdownText.fontSize = 250;
            //start flying
            Invoke("blastOff", 1.5f);

        }
        if (RocketPig.die){
            // bestScore.text = PlayerPrefs.GetInt("highscore2").ToString("00");
            // totalCounter.text = starCounter.ToString("00");
            
        }

    }

    //left tap
    public void clickLeftFinger()
    {
        if (leftFinger.interactable == true)
        {
            fuelCounter += 1;
            totalScoreFinal +=1;
            leftFinger.interactable = false;
            rightFinger.interactable = true;
            if (startCountdownTrigger == false)
            {
                startCountdownTrigger = true;
            }
        }
    }

    //right tap
    public void clickRightFinger()
    {
        if (rightFinger.interactable == true)
        {
            fuelCounter += 1;
            totalScoreFinal +=1;
            rightFinger.interactable = false;
            leftFinger.interactable = true;
            if (startCountdownTrigger == false)
            {
                startCountdownTrigger = true;

            }
        }
    }

    //start flying
    private void blastOff()
    {
        //get rid off counddown
        if (blastOffTriggered == false)
        {
            //Debug.Log ("blastOff!");
            countdownText.gameObject.SetActive(false);
            blastOffTriggered = true;
            startTime = Time.time;
            launchPadAnimator.SetTrigger("LaunchPanelDisappear");
            piggyAnimator.SetTrigger("SetPiggyToNeutralPosition");
            backgroundAnimator.SetTrigger("StartMovingSky");
            StartCoroutine(allowPigMovement());
        }
    }

    IEnumerator allowPigMovement (){
        yield return new WaitForSeconds(0.8f);
        piggyAnimator.enabled=false;

    }
}

