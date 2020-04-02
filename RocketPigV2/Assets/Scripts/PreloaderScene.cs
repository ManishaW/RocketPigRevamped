using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CloudOnce;

public class PreloaderScene : MonoBehaviour
{
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 1.7f;


	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetInt("muteSfx", 0);
		PlayerPrefs.SetInt("muteBgMusic", 0);
		fadeGroup = FindObjectOfType<CanvasGroup> ();
		fadeGroup.alpha = 1;
		//preload game!

		//if loadtime is longgg
		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//fade in 
		if (Time.time < minimumLogoTime) {
			fadeGroup.alpha = 1 - Time.time;
		}
		if (Time.time > minimumLogoTime && loadTime != 0) {
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1) {
				SceneManager.LoadScene ("Main Menu");;
			}
		}
			

	}
}
