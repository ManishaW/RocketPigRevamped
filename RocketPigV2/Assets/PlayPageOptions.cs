using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPageOptions : MonoBehaviour
{
    public AudioSource[] allAudio;
    public static AudioSource mainMusic;
    public static AudioSource popSound;
    AudioSource rocketLauncherSound;
    public static AudioSource gameoverSound;
    public static AudioSource splatSound;
    public static AudioSource dizzySound;
    public static AudioSource magneticSound;
    public static AudioSource catchStarSound;
    public static AudioSource rockItSoundClip;
    public static AudioSource fairyDustSound;
    public static AudioSource zap;
    public static AudioSource click1Sound;
    public static AudioSource click2Sound;

    // Start is called before the first frame update
    void Start()
    {
        allAudio = GetComponents<AudioSource>();
        popSound = allAudio[0];
        mainMusic = allAudio[1];
        rocketLauncherSound = allAudio[2];
        gameoverSound = allAudio[3];
        splatSound = allAudio[4];
        dizzySound = allAudio[5];
        magneticSound = allAudio[6];
        catchStarSound = allAudio[7];
        rockItSoundClip = allAudio[8];
        fairyDustSound = allAudio[9];
        zap = allAudio[10];
        click1Sound = allAudio[11];
        click2Sound = allAudio[12];
        // var test = PlayerPrefs.GetInt("muteBgMusic");
        // Debug.Log(test);
        if (PlayerPrefs.GetInt("muteBgMusic") == 1)
        {
            mainMusic.mute = true;
            rockItSoundClip.mute = true;
        }
        if (PlayerPrefs.GetInt("muteSfx") == 1)
        {
            rocketLauncherSound.mute = true;
            gameoverSound.mute = true;
            popSound.mute = true;
            splatSound.mute = true;
            magneticSound.mute = true;
            catchStarSound.mute = true;
            dizzySound.mute = true;
            fairyDustSound.mute = true;
            zap.mute = true;

        }

        mainMusic.Play();
        rocketLauncherSound.Play();



    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void playGameOverSound()
    {
        gameoverSound.Play();
    }

    public static void playPopSound()
    {
        popSound.Play();
    }
    public static void playClick1Sound()
    {
        click1Sound.Play();
    }
    public static void playClick2Sound()
    {
        click2Sound.Play();
    }
    public static void playSplatSound()
    {
        splatSound.Play();
        dizzySound.Play();
    }
    public static void playMagneticSound()
    {
        magneticSound.Play();
    }
    public static void playStarCatchSound()
    {
        catchStarSound.Play();
    }
    public static void pauseMainMusic()
    {
        mainMusic.Pause();
        rockItSoundClip.Play();

    }
    public static void unpauseMainMusic()
    {
        mainMusic.Play();

    }
    public static void speedUpMainMusic(){
        mainMusic.pitch = 1.15f;
    }

    public static void normalMainMusic(){
        mainMusic.pitch = 1.0f;
    }
    public static void playRainbowEntersSound()
    {
        fairyDustSound.Play();
    }
    public static void playZapTapSound()
    {
        zap.Play();
    }

}
