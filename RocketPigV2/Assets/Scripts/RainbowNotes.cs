using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in the future, there will be an array of powerup. Randomize and drop one

public class RainbowNotes : MonoBehaviour
{
    public GameObject musicNote1;
    public GameObject newmusicNote1;

    // public GameObject musicNote2;
    // public GameObject newmusicNote2;

    // public GameObject musicNote3;
    // public GameObject newmusicNote3;

    // public GameObject musicNote4;
    // public GameObject newmusicNote4;

    // public GameObject musicNote5;
    // public GameObject newmusicNote5;

    // public GameObject musicNote6;
    // public GameObject newmusicNote6;

    // public GameObject musicNote7;
    // public GameObject newmusicNote7;

    GameObject spawnNote;
    GameObject newSpawnNote;
    // Use this for initialization
    void Start()
    {
        float randoTime = Random.Range(0.04f, 0.07f);
        InvokeRepeating("makeNote", 2f, randoTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //should randomize the type of power up once I make more
    void makeNote()
    {
        if (RocketPig.die == false && PlayGameScene.fuelCounter > 0 && PlayGameScene.blastOffTriggered && RocketPig.musicNoteShower)
        {
            // int rando = Random.Range(1, 3); 

            // if (rando == 1)
            // {
                spawnNote = musicNote1;
                newSpawnNote = newmusicNote1;
            // }
            // else if (rando == 2)
            // {
            //     spawnNote = musicNote2;
            //     newSpawnNote = newmusicNote2;
            // }
            // else if (rando == 3)
            // { 
            //     spawnNote = musicNote3;
            //     newSpawnNote = newmusicNote3;
            // }
            // else if (rando == 4)
            // { 
            //     spawnNote = musicNote4;
            //     newSpawnNote = newmusicNote4;
            // }
            // else if (rando == 5)
            // { 
            //     spawnNote = musicNote5;
            //     newSpawnNote = newmusicNote5;
            // }
            // else if (rando == 6)
            // { 
            //     spawnNote = musicNote6;
            //     newSpawnNote = newmusicNote6;
            // }
            // else if (rando == 7)
            // { 
            //     spawnNote = musicNote7;
            //     newSpawnNote = newmusicNote7;
            // }
            float scale = Random.Range(9.0f, 20.0f);

            Vector3 position = new Vector3(Random.Range(-350, 350), 800, 0);
            newSpawnNote = Instantiate(spawnNote, position, Quaternion.identity) as GameObject;
            newSpawnNote.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            newSpawnNote.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -30, 0);
            newSpawnNote.transform.localScale = new Vector3(scale, scale, 0);

        }
    }
}
