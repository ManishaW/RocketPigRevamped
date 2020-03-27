using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in the future, there will be an array of powerup. Randomize and drop one

public class PowerUpFall : MonoBehaviour {
	public GameObject powerUpImmune;
	public GameObject newPowerUpImmune;
	public GameObject magneticPowerUp;
	public GameObject newMagneticPowerUp;	
	
	GameObject spawnPowerUp;
	GameObject spawnPowerUpNew;
	// Use this for initialization
	void Start () {
		float randoTime = Random.Range(5,10);
		InvokeRepeating ("makePowerUp", 10f, randoTime);

	}

	// Update is called once per frame
	void Update () {
	}


	//should randomize the type of power up once I make more
	void makePowerUp(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0 && PlayGameScene.blastOffTriggered && !RocketPig.rainbowSequenceOn) {
			//randomize 1-3
			int rando = Random.Range(1,3); //only 1 and 2 rando
			// int rando = 1;
			if (rando==1){
				spawnPowerUp = powerUpImmune;
				spawnPowerUpNew = newPowerUpImmune;
			}else if(rando==2){
				spawnPowerUp = magneticPowerUp;
				spawnPowerUpNew = newMagneticPowerUp;
			}
			Vector3 position = new Vector3 (Random.Range (-350, 350), 800, 0);		
			spawnPowerUpNew = Instantiate (spawnPowerUp, position, Quaternion.identity) as GameObject;
			spawnPowerUpNew.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			spawnPowerUpNew.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-30,0);

		}
	}
}
