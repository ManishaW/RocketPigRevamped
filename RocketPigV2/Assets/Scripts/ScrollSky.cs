using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSky : MonoBehaviour {
	public static float speed=0f;

	// Use this for initialization
	void Start () {
		speed= 0f;
	}

	// Update is called once per frame
	void Update () {
		// while the pig is flying and not dead
		// if (PlayGameScene.blastOffTriggered == true && RocketPig.die==false) {
			//speed that sky is scrolling
			if (PlayGameScene.blastOffTriggered && !RocketPig.die){
    			StartCoroutine(startMovingSky(0f));


			}
			if (RocketPig.die){
				speed= 0f;
			}

		// }
	}
 
    IEnumerator startMovingSky(float duration)
    {
        yield return new WaitForSeconds(duration);
		// if (speed<0.5) speed += 0.05f ;
		speed += 3 * Time.deltaTime;
		Mathf.Clamp (speed, 0f, 0.7f);
		// speed=0.65f;
		speed=0.68f;

		Vector2 bgPos = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = bgPos;


    }

}
