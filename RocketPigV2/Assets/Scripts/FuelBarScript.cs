using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FuelBarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;
    public static bool fuelout;
    public float fuelstart;
    public static float fuelPresent = 0;
    public GameObject fuelObj;
    public GameObject rainbowObj;
    public GameObject fuelWarningText;
    Animator fuelAnimator;
    float amount;
    public Text fuelCounterScore;

    void Start()
    {
        fuelAnimator = fuelObj.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //fuel up
        if (PlayGameScene.blastOffTriggered == false)
        {
            // Debug.Log(PlayGameScene.fuelCounter);
            amount = ((float)PlayGameScene.fuelCounter / 75);
            content.fillAmount = amount;
            fuelstart = (float)PlayGameScene.fuelCounter;

        }
        if (RocketPig.rainbowSequenceOn)
        {
            amount = ((float)PlayGameScene.fuelCounter / 75);
            content.fillAmount = amount;
            fuelstart = (float)PlayGameScene.fuelCounter;
            PlayGameScene.startTime = Time.time;
            fuelWarningText.SetActive(false);
            fuelAnimator.SetTrigger("FuelAmple");
            rainbowObj.SetActive(true);
        }
        if (!RocketPig.rainbowSequenceOn){
            rainbowObj.SetActive(false);
        }
        //fuel loss over time
        if (PlayGameScene.blastOffTriggered == true && fuelout == false && RocketPig.die == false && !RocketPig.rainbowSequenceOn)
        {
            fuelPresent = fuelstart / 75 - ((Time.time - PlayGameScene.startTime) / 75);

            content.fillAmount = fuelPresent;

            //fuel is out!
            PlayGameScene.fuelCounter = (int)(fuelPresent * 75);
            fuelCounterScore.text = PlayGameScene.fuelCounter.ToString("00");


            if (fuelPresent > 0.15f)
            {
                // GuitarFall.spawnedGuitarOnce = false;
                fuelAnimator.SetTrigger("FuelAmple");
                GuitarFall.spawnedGuitarOnce = false;
                PlayPageOptions.normalMainMusic();
                fuelWarningText.SetActive(false);

            }

            if (fuelPresent < 0.15f && !GuitarFall.spawnedGuitarOnce && !RocketPig.rainbowSequenceOn)
            {
                fuelAnimator.SetTrigger("FuelBarLow");
                float randomDelay = Random.Range(0f, 5f);
                Invoke("spawnGuitarPower", randomDelay);
                GuitarFall.spawnedGuitarOnce = true;

                PlayPageOptions.speedUpMainMusic();
                fuelWarningText.SetActive(true);
            }


            // if (RocketPig.rainbowSequenceOn)
            // {
            //     GuitarFall.spawnedGuitarOnce = false;
            // }

            if (fuelPresent <= 0.01f)
            {
                RocketPig.die = true;
                PlayPageOptions.playGameOverSound();

            }

        }

    }

    void spawnGuitarPower()
    {
        GuitarFall.triggerGuitarSpawn();
    }
}

