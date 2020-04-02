using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketPig : MonoBehaviour
{
    public Rigidbody2D upwardForce;
    public GameObject pig;
    public bool flipped = false;
    public static bool die = false;
    public static bool invincible = false;
    public static bool magnetic = false;
    public GameObject invinciblePig;
    public GameObject magneticPig;
    public Sprite normalPig;

    public Text starsFinal;
    public Text fuelFinal;
    Animator immuneAnimator;
    Animator rainbowAnimator;
    Animator guitarAnimator;
    public GameObject immuneBubble;
    public GameObject rainbowBkgd;
    public GameObject guitar;
    public GameObject RockItPigText;
    public GameObject NewHighscore;
    public static bool rainbowSequenceOn = false;
    public static bool musicNoteShower = false;
    public static bool diedByCollision = false;
    float initTiltedPosition;
    float fuelAtRainbowBegins;
    float fuelAtRainbowEnds;
    bool newHighscoreReached;
    DeviceOrientation orient ;
    void Awake()
    {
        immuneAnimator = immuneBubble.GetComponent<Animator>();
        rainbowAnimator = rainbowBkgd.GetComponent<Animator>();
        guitarAnimator = guitar.GetComponent<Animator>();
    }
    // Use this for initialization
    void Start()
    {
        // orient = Input.deviceOrientation;
        // Debug.Log(orient);
        pig = GameObject.Find("Pig");
        upwardForce = pig.GetComponent<Rigidbody2D>();
        die = false;
        magnetic = false;
        normalPig = pig.GetComponent<Image>().sprite;
        FuelBarScript.fuelout = false;
        rainbowSequenceOn = false;
        musicNoteShower = false;
        diedByCollision = false;
        newHighscoreReached =false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (pig.transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        //make pig fly when blastOff was triggered (in PlaySceneScene)
        if (PlayGameScene.blastOffTriggered && Time.timeScale!=0)
        {
            if (orient == DeviceOrientation.LandscapeLeft){
                transform.Translate(Input.acceleration.z * -2f, 0, 0);
            }else if (orient == DeviceOrientation.LandscapeRight){
                transform.Translate(Input.acceleration.z * 2f, 0, 0);
            }else{
                transform.Translate(Input.acceleration.x * 2f, 0, 0);
            }
            // transform.Translate(dir.y * 2.5f,0,0);

        }
        if (FuelBarScript.fuelout == true)
        {
            stopFlying();
        }
        //resrict sides, do not let the pig move outside the screen
        rightBorder = rightBorder - 4;
        leftBorder = leftBorder + 4;
        if (transform.position.x > (rightBorder))
        {
            Vector3 pos = transform.position;
            pos.x = rightBorder;
            transform.position = pos;
        }
        //-34, +(pig.GetComponent<BoxCollider2D>().bounds.size.x/2)
        if (transform.position.x < (leftBorder))
        {
            Vector3 pos = transform.position;
            pos.x = leftBorder;
            transform.position = pos;
        }

        if (die == true)
        {
            stopFlying();
        }

        //if highscore is surpassed
        // if (PlayGameScene.starCounter > PlayerPrefs.GetInt("highscore")) {
        // 	//trigger animation saying: new highscore!

        // }
        if (PlayGameScene.totalScoreFinal> PlayerPrefs.GetInt("highscore2")&&!newHighscoreReached){
            NewHighscore.SetActive(true);
            newHighscoreReached =true;
        }
    }

    void stopFlying()
    {
        //(int)PlayGameScene.fuelCounter +
        PlayPageOptions.playSplatSound();
        // totalScore =  PlayGameScene.starCounter;
        die = true;
        //update high score
        // if (totalScore > PlayerPrefs.GetInt("highscore2"))
        // {
        //     PlayerPrefs.SetInt("highscore2", totalScore);
        //     Leaderboards.RocketPigHighScore.SubmitScore(totalScore);
        // }
        // Invoke("destroyPig", 3);
        ScrollSky.speed = 0f;
        upwardForce.gravityScale = 75;
        if (transform.localScale.y > 0 && !flipped)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            flipped = true;
        }

    }

    //pig physics collision with another object
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Comet" && invincible == false)
        {
            PlayPageOptions.playGameOverSound();
            diedByCollision = true;
            stopFlying();
        }

    }

    //non-physics collision with another object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "star(Clone)" && !die)
        {
            PlayPageOptions.playStarCatchSound();
            //destory upon catching star and increment star counter, play sound
            Destroy(col.gameObject);
            PlayGameScene.totalScoreFinal +=2;

        }
        if (col.gameObject.name == "powerupImmune(Clone)" && !die)
        {
            doneInvincible();
            doneMagnetic();
            //start invinsible, destroy the powerup object
            Destroy(col.gameObject);
            invincible = true;
            //turn the collider box into a trigger
            pig.GetComponent<Collider2D>().isTrigger = true;
            //change the sprite of the pig to the bubble protected
            immuneBubble.SetActive(true);
            PlayPageOptions.playPopSound();

            Invoke("triggerWarningInvincible", 2);
            Invoke("doneInvincible", 4);

        }
        if (col.gameObject.name == "powerupMagnetic(Clone)" && !die)
        {
            doneMagnetic();
            doneInvincible();
            //start invinsible, destroy the powerup object
            Destroy(col.gameObject);
            magneticPig.SetActive(true);
            PlayPageOptions.playMagneticSound();
            Invoke("doneMagnetic", 6);
            magnetic = true;

        }
        if (col.gameObject.name == "DiamondPowerUp(Clone)" && !die)
        {
            doneInvincible();
            doneMagnetic();
            PlayPageOptions.pauseMainMusic();
            Destroy(col.gameObject);
            rainbowAnimator.SetTrigger("ShowRainbow");
            guitarAnimator.SetTrigger("GuitarPow");
            rainbowSequenceOn = true;
            PlayPageOptions.playRainbowEntersSound();
            RockItPigText.SetActive(true);
            musicNoteShower = true;
            fuelAtRainbowBegins = PlayGameScene.fuelCounter;
            Invoke("doneRainbowSequence", 12);
            Invoke("doneMusicNoteShower", 8);
        }
        if ((col.gameObject.name == "musicNote1(Clone)" || col.gameObject.name == "musicNote2(Clone)" || col.gameObject.name == "musicNote3(Clone)" || col.gameObject.name == "musicNote4(Clone)" || col.gameObject.name == "musicNote5(Clone)" || col.gameObject.name == "musicNote6(Clone)" || col.gameObject.name == "musicNote7(Clone)") && !die)
        {
            Destroy(col.gameObject);
            PlayGameScene.fuelCounter = PlayGameScene.fuelCounter+0.5f;
            PlayGameScene.totalScoreFinal +=1;

        }
    }

    void doneMagnetic()
    {
        magneticPig.SetActive(false);
        magnetic = false;

    }
    void doneMusicNoteShower()
    {
        musicNoteShower = false;

    }
    void doneRainbowSequence()
    {
        PlayPageOptions.unpauseMainMusic();
        rainbowAnimator.SetTrigger("HideRainbow");
        rainbowSequenceOn = false;
        RockItPigText.SetActive(false);
        fuelAtRainbowEnds = PlayGameScene.fuelCounter;
        PlayGameScene.totalFuelAccumulated = PlayGameScene.totalFuelAccumulated + (fuelAtRainbowEnds-fuelAtRainbowBegins);

    }

    void triggerWarningInvincible()
    {
        immuneAnimator.SetTrigger("PigImmuneWarning");
    }
    void destroyPig()
    {
        //destroy pig object when it dies
        Destroy(pig);
    }

    void doneInvincible()
    {
        // //finish invincible
        invincible = false;
        // // turn the colliber box back to a normal collider
        pig.GetComponent<Collider2D>().isTrigger = false;
        immuneAnimator.SetTrigger("PigNeutralBubble"); 
        immuneBubble.SetActive(false);
        PlayPageOptions.playPopSound();
        
    }


}
