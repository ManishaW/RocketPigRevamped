using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuOptions : MonoBehaviour
{

	public static AudioSource[] allAudio;
	public static AudioSource BGM;
	public static AudioSource soundClick;
	public static AudioSource playGameMusic;
	public static AudioSource starCaught;
	public static AudioSource fuelWarning;
	public static AudioSource signDisappearSound;
	public static AudioSource rocketLauncherBuild;
	public static bool muteAllSounds;

    Animator m_Animator;
	GameObject signPost;
	public GameObject settingsMenu;
	void Awake(){
		signPost = GameObject.Find("PostObject");
		m_Animator = signPost.GetComponent<Animator>();

	}
	void Start ()
	{
		allAudio = GetComponents<AudioSource> ();
		BGM = allAudio [0];
		soundClick = allAudio [1];
		playGameMusic = allAudio [2];
		starCaught = allAudio [3];
		fuelWarning = allAudio [4];
		signDisappearSound = allAudio [5];
		rocketLauncherBuild = allAudio [6];
		muteAllSounds = false;
		
		Debug.Log(m_Animator);
		if (SceneManager.GetActiveScene().name==("Main menu")){
			BGM.Play();
		}
		if (SceneManager.GetActiveScene().name==("Play page")){
			BGM.Stop ();
			// playGameMusic.Loop();
			// playGameMusic.Play ();
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}


	
	// Update is called once per frame
	void Update ()
	{
		

	}

	public void playOnClick ()
	{
		m_Animator.SetTrigger("postDisappear");
		StartCoroutine (playSound ());
		// SceneManager.LoadScene("NewPlayPage");
			BGM.Stop();
			playGameMusic.Play();
			rocketLauncherBuild.Play();

	}

	
	IEnumerator playSound ()
	{
		if (muteAllSounds == false) {
			// soundClick.Play ();
			signDisappearSound.Play();
			yield return new WaitForSeconds (0.3f);
		}
       

	}

	public void highScoreOnClick ()
	{
		Debug.Log ("high score button clicked");
		StartCoroutine (playSound ());
	}

	public void leaderboardOnClick ()
	{
		Debug.Log ("leaderboard button clicked");
		StartCoroutine (playSound ());
	}

	public void settingsOnClick ()
	{
		Debug.Log ("settings button clicked");
		m_Animator.SetTrigger("postDisappear");
		StartCoroutine (playSound ());
		StartCoroutine(openSettingsMenu(0.75f));

	}
	IEnumerator openSettingsMenu(float duration){
		yield return new WaitForSeconds (duration);
		soundClick.Play();
		settingsMenu.SetActive(true);

	}

	public void closeSettingMenuOnClick ()
	{
		Debug.Log ("close settings menu clicked");
		settingsMenu.SetActive(false);
		// soundClick.Play();
		m_Animator.SetTrigger("postAppear");
		signDisappearSound.Play();
	}

	public void helpOnClick ()
	{
		Debug.Log ("help button clicked");
		StartCoroutine (playSound ());
	}

	public void soundOnClick ()
	{
		
		StartCoroutine (playSound ());
		if (BGM.mute == false) {
			BGM.mute = true;
			muteAllSounds = true;
			Debug.Log ("unmute");
		} else {
			BGM.mute = false;
			muteAllSounds = false;
			Debug.Log ("mute");
		}
	}
}

