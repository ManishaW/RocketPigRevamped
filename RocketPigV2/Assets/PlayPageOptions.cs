using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPageOptions : MonoBehaviour
{
	public  AudioSource[] allAudio;
	public static AudioSource starCaught;

    // Start is called before the first frame update
    void Start()
    {
		allAudio = GetComponents<AudioSource> ();
		starCaught = allAudio [1];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
