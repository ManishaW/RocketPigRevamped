using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePowerUp : MonoBehaviour
{
    public static UltimatePowerUp instance;
    public GameObject guitar;
    public GameObject newGuitar;
	public static bool spawnedUltOnce;
	public static bool allowUltSpawn;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
		spawnedUltOnce = false;
       
    }

    // Update is called once per frame
    void Update()
    {

    }
	public static void triggerUltSpawn(){
		instance.Invoke("makeUlt",0.3f);
	}

    public void makeUlt()
    {
        Vector3 position = new Vector3(Random.Range(-3250, 325), 800, 0);
        newGuitar = Instantiate(guitar, position, Quaternion.identity) as GameObject;
        newGuitar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newGuitar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -20, 0);
    }
}
