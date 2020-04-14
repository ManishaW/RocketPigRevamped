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
    public GameObject UFO;
    public GameObject rainbowOrb;
    Animator fuelAnimator;
    float amount;
    public Text fuelCounterScore;
    Rigidbody2D rg;
    
    void Start()
    {
        fuelAnimator = fuelObj.GetComponent<Animator>();
        GuitarFall.spawnedGuitarOnce = false;

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
              
                fuelAnimator.SetBool("FuelAmpleBool", true);
                // GuitarFall.spawnedGuitarOnce = false;
                PlayPageOptions.normalMainMusic();
                fuelWarningText.SetActive(false);

            }

            if (fuelPresent < 0.15f && !GuitarFall.spawnedGuitarOnce && !RocketPig.rainbowSequenceOn)
            {
                GuitarFall.spawnedGuitarOnce = true;
                UFO.SetActive(true);
                float rando = Random.Range(1.5f,3.7f);
		        Invoke("makeOrbActive",rando);
                fuelAnimator.SetBool("FuelAmpleBool", false);
                PlayPageOptions.speedUpMainMusic();
                fuelWarningText.SetActive(true);
            }


            if (fuelPresent <= 0.01f)
            {
                RocketPig.die = true;
                PlayPageOptions.playGameOverSound();

            }

        }

    }
    
    void makeOrbActive(){
        Debug.Log("test here");
        rainbowOrb.SetActive(true);
    }
    // void spawnGuitarPower()
    // {
    //     GuitarFall.triggerGuitarSpawn();
    // }
}

