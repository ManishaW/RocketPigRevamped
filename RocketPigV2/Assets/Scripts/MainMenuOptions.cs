using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuOptions : MonoBehaviour
{

    public static AudioSource[] allAudio;
    public static AudioSource BGM;
    public static AudioSource soundClick;
    // public static AudioSource playGameMusic;
    // public static AudioSource starCaught;
    // public static AudioSource fuelWarning;
    public static AudioSource signDisappearSound;
    public static AudioSource rocketLauncherBuild;
    public static AudioSource squeak;
    public static AudioSource popClick;
    bool toggleBkgdMusicMute;
    bool toggleSfxMute;
    Animator m_Animator;
    GameObject signPost;
    public TextMeshProUGUI highScore;
    public GameObject settingsMenu;
    public GameObject bkgdMusicCheck;
    public GameObject sfxCheck;
    public GameObject title;
    void Awake()
    {
        signPost = GameObject.Find("PostObject");
        m_Animator = signPost.GetComponent<Animator>();

    }
    void Start()
    {
        allAudio = GetComponents<AudioSource>();
        BGM = allAudio[0];
        soundClick = allAudio[1];
        // playGameMusic = allAudio[2];
        // starCaught = allAudio[3];
        // fuelWarning = allAudio[4];
        signDisappearSound = allAudio[2];
        squeak = allAudio[3];
        popClick= allAudio[4];
        // rocketLauncherBuild = allAudio[6];
        // muteAllSounds = false;
        setMusicSettings();
        highScore.text = PlayerPrefs.GetInt("highscore2").ToString();
        if (SceneManager.GetActiveScene().name == ("Main menu"))
        {
            BGM.Play();
        }
      
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void setMusicSettings (){
        if (PlayerPrefs.GetInt("muteBgMusic")==1){
          BGM.mute=true;

        }else{
          BGM.mute=false;
        }

        if (PlayerPrefs.GetInt("muteSfx")==1){
            soundClick.mute = true;
            signDisappearSound.mute = true;
            squeak.mute=true;
            popClick.mute = true;
        }else{
            soundClick.mute = false;
            signDisappearSound.mute = false;
            squeak.mute=false;
            popClick.mute = false;

        }
      
    }

    void setMusicSettingsVisuals(){
         if (PlayerPrefs.GetInt("muteBgMusic")==1){
           bkgdMusicCheck.SetActive(false);
        }else{
           bkgdMusicCheck.SetActive(true); 
        }

        if (PlayerPrefs.GetInt("muteSfx")==1){
           sfxCheck.SetActive(false);
        }else{
            sfxCheck.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void playOnClick()
    {
        soundClick.Play();
        m_Animator.SetTrigger("postDisappear");
        StartCoroutine(playSound());
        BGM.Stop();
        // playGameMusic.Play();
        // rocketLauncherBuild.Play();
 		// Invoke("goToLaunchScene", 0.5f);
        SceneManager.LoadSceneAsync("LaunchScene");

    }
	void goToLaunchScene (){
        // SceneManager.LoadSceneAsync("LaunchScene");
         SceneManager.LoadSceneAsync("LaunchScene");

    }

    IEnumerator playSound()
    {

        // soundClick.Play ();
        signDisappearSound.Play();
        yield return new WaitForSeconds(0.3f);


    }

    public void highScoreOnClick()
    {
        Debug.Log("high score button clicked");
        StartCoroutine(playSound());
    }

    public void leaderboardOnClick()
    {
        Debug.Log("leaderboard button clicked");
        StartCoroutine(playSound());
    }

    public void settingsOnClick()
    {
        Debug.Log("settings button clicked");
        m_Animator.SetTrigger("postDisappear");
        StartCoroutine(playSound());
        StartCoroutine(openSettingsMenu(0.7f));

    }
    IEnumerator openSettingsMenu(float duration)
    {
        yield return new WaitForSeconds(duration);
        title.SetActive(false);
        settingsMenu.SetActive(true);
        setMusicSettingsVisuals();
    }

    public void playSqueakSound()
    {
       squeak.Play();

    }
    public void closeSettingMenuOnClick()
    {
        Debug.Log("close settings menu clicked");
        settingsMenu.SetActive(false);
        title.SetActive(true);

        m_Animator.SetTrigger("postAppear");
        signDisappearSound.Play();
    }



    public void toggleMuteOnOffOnClick()
    {
        popClick.Play();
        var muteBgBool = PlayerPrefs.GetInt("muteBgMusic");
        if (muteBgBool==1){
            muteBgBool=0;
        }else{
            muteBgBool=1;
        }
        PlayerPrefs.SetInt("muteBgMusic",muteBgBool);
        setMusicSettings();
        setMusicSettingsVisuals();
  
    }


    public void toggleSfxMuteOnOffOnClick()
    {
        var muteSfxBool = PlayerPrefs.GetInt("muteSfx");
        if (muteSfxBool==1){
            muteSfxBool=0;
        }else{
            muteSfxBool=1;
        }
        PlayerPrefs.SetInt("muteSfx", muteSfxBool);
        popClick.Play();
        
        // sfxCheck.SetActive(!toggleSfxMute);
        setMusicSettings();
        setMusicSettingsVisuals();
        // if (!toggleSfxMute)
        // {
        //     soundClick.mute = false;
        //     signDisappearSound.mute = false;
        //     squeak.mute=false;

        // }
        // else
        // {
        //     soundClick.mute = true;
        //     signDisappearSound.mute = true;
        //     squeak.mute=true;


        // }

    }


    public void rateUsRedirectOnClick()
    {
        soundClick.Play();
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Wannibe.RocketPig&hl=en_CA");


    }

    public void resetHighscoreOnClick()
    {
        soundClick.Play();
        PlayerPrefs.SetInt("highscore2", 0);
        Debug.Log("Reset highscore");
    }
}

