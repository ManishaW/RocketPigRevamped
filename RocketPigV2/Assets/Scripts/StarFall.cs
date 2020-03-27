using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour {
	public GameObject star;
	public GameObject newStar;


	// Use this for initialization
	void Start () {
		float randoTime = Random.Range (0.7f, 1.3f);
		InvokeRepeating ("makeStar", 5f, randoTime);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void makeStar(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0 && PlayGameScene.blastOffTriggered && !RocketPig.rainbowSequenceOn) {
			Vector3 position = new Vector3 (Random.Range (-350, 350), 800, 0);
			newStar = Instantiate (star, position, Quaternion.identity) as GameObject;
			newStar.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			newStar.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-40,0);
		}
	}
}
