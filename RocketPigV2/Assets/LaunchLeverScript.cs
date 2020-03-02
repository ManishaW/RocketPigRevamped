using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaunchLeverScript : MonoBehaviour
{
    public static bool launchedLeverPulled = false;
    // Start is called before the first frame update
    public Button leftFinger;
    public Button rightFinger;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RocketPig.die)
        {
            this.gameObject.SetActive(false);
        }
    
    }

    void OnMouseDrag()
    {

        Debug.Log("hit");
        leftFinger.interactable = false;
        rightFinger.interactable = false;
        // rightFinger.gameObject.SetActive(false);
        //Testing
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 280, 0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.mousePosition.x < 620 && Input.mousePosition.x > 110)
        {
            transform.position = objPosition;
        }
        if (Input.mousePosition.x < 300)
        {
            Debug.Log("AND LAUNCH!!!");
            launchedLeverPulled = true;
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(launchLeverDisappear());

        
        }



    }
    IEnumerator launchLeverDisappear()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);


    }
}


// Vector3 mousePosition = new Vector3(625, Input.mousePosition.y, 0);
// Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

// if (Input.mousePosition.y<300 && Input.mousePosition.y>60){
//     transform.position = objPosition;
// }
// if (Input.mousePosition.y <120){
//     Debug.Log("AND LAUNCH!!!");
//     launchedLeverPulled = true;
//     this.GetComponent<Collider2D>().enabled = false;
//     // gameObject.SetActive(false);
// }