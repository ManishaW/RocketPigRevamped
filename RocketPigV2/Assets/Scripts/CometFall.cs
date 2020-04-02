using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometFall : MonoBehaviour
{
    public GameObject cometType1;
    public GameObject cometType2;
    GameObject cometToSpawn;
    GameObject newComet;
    bool spawningTriggered;
    public static CometFall instance;
    void Start()
    {
        //   Debug.Log("Screen Width : " + (Screen.width-200f)/4f);
        // float startRando = Random.Range (0.5f,1.5f);
        // float endRando = Random.Range (2.5f,4f);
        // float randoTime = Random.Range(1f, 5f);
        float randoTime = 0.7f;
        // InvokeRepeating("startPhysicalSpawning", 5f, randoTime);

    }
    void Update()
    {
       
    }
    void Awake()
    {
        instance = this;
    }
    public static void cueSpawning()
    {
        instance.test2();
        // Debug.Log("cueSpawn");
    }
    void test2()
    {
        // InvokeRepeating("test", 0.5f, 3.5f);
        InvokeRepeating("test", 0.5f, 5f);
    }
    void test()
    {
        SpawningAlgorithm.generateMatrixWithPath();
        // SpawningAlgorithm.printArray(SpawningAlgorithm.generatedMatrix);

        for (int y = 0; y < 5; y++)
        {
           
            StartCoroutine(startPhysicalSpawning(y, 1.5f + (1f * y)));
            
        }

    }
    IEnumerator startPhysicalSpawning(int rowNum, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // Debug.Log("spawning row "+PlayGameScene.blastTime);
        if (RocketPig.die == false && PlayGameScene.fuelCounter > 0 && PlayGameScene.blastOffTriggered && !RocketPig.musicNoteShower)
        {
            // Debug.Log("spawning row yall " + rowNum);
            // SpawningAlgorithm.printArray(SpawningAlgorithm.generatedMatrix);
            if (SpawningAlgorithm.generatedMatrix[rowNum, 0] == -1){
                instantiateCometWithProperties(new Vector3(Random.Range(-390, -270), 810, 0));
            } 
            if (SpawningAlgorithm.generatedMatrix[rowNum, 1] == -1){
                 instantiateCometWithProperties(new Vector3(Random.Range(-170, -90), 850, 0));
            }
            if (SpawningAlgorithm.generatedMatrix[rowNum, 2] == -1){
                instantiateCometWithProperties(new Vector3(Random.Range(90, 170), 830, 0));
            } 
            if (SpawningAlgorithm.generatedMatrix[rowNum, 3] == -1){
                instantiateCometWithProperties(new Vector3(Random.Range(270, 390), 870, 0));
            }

        }

        // while (RocketPig.die == false && PlayGameScene.fuelCounter > 0 && PlayGameScene.blastOffTriggered && !RocketPig.rainbowSequenceOn){
        //     StartCoroutine(spawnRow());
        // }




    }

    void instantiateCometWithProperties(Vector3 position)
    {
        // Debug.Log("instantiate @"+PlayGameScene.blastTime);
        int rando = Random.Range(1, 5); //only 1 and 2 rando
                                        // int rando = 1;
        if (rando == 1 ||rando == 3)
        {
            cometToSpawn = cometType1;
        }
        else if (rando == 2 || rando == 4)
        {
            cometToSpawn = cometType2;

        }
        // yield return new WaitForSeconds(delay);

        float scale = Random.Range(2.0f, 3.0f);
        newComet = Instantiate(cometToSpawn, position, Quaternion.identity) as GameObject;
        newComet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newComet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, Random.Range(-60, -50), 0);
        newComet.transform.localScale = new Vector3(scale, scale, 0);
        // newComet.transform.Rotate(0f, 0f, Random.Range(0f, 180f));

    }



}
