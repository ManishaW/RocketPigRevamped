using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreOptionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void backToMainMenu()
    {

        // playGameMusic.Play();
        // rocketLauncherBuild.Play();
        // waitXseconds(2.0f);
        SceneManager.LoadScene("Main menu");



    }
}
