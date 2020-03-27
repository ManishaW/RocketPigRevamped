using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas defaultCanvas;
    public GameObject pig;
	public GameObject helpMenuCanvas;
	bool toggleMute;
    // Rigidbody piggyRigidbody;
    // Use this for initialization
    void Start()
    {
        pig = GameObject.Find("Pig");
        // piggyRigidbody = pig.GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void pauseClick()
    {
        
        pauseCanvas.gameObject.SetActive(true);
        defaultCanvas.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 0;
        // pig.SetActive(false);
        PlayPageOptions.playClick1Sound();
        pig.transform.Translate(0, 0, 0);
    }
    public void showHelpMenuCanvas(){
        //show canvas 
        pauseCanvas.gameObject.SetActive(false);
        helpMenuCanvas.gameObject.SetActive(true);
        defaultCanvas.GetComponent<CanvasGroup>().interactable = false;
        PlayPageOptions.playClick2Sound(); 
    }
    public void hideHelpMenuCanvas(){
        helpMenuCanvas.gameObject.SetActive(false);
        PlayPageOptions.playClick2Sound();
        resumeClick();
    }

    public void restartOnClick()
    {
        SceneManager.LoadScene("LaunchScene");
        Time.timeScale = 1;
        PlayPageOptions.playClick2Sound();

    }

    public void resumeClick()
    {
        pauseCanvas.gameObject.SetActive(false);
        defaultCanvas.GetComponent<CanvasGroup>().interactable = true;
        Time.timeScale = 1;
        PlayPageOptions.playClick2Sound();
        // pig.SetActive(true);

    }

	
  


}
