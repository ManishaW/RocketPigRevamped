using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSky : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
	public bool gameoverRain;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		// while the pig is flying and not dead
		if ((PlayGameScene.blastOffTriggered == true && RocketPig.die==false) || gameoverRain) {
			Vector2 bgPos = new Vector2 (0, Time.time * speed);
			GetComponent<Renderer> ().material.mainTextureOffset = bgPos;
		}
		
	}
 
}