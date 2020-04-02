using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Monetization;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class Adcaller : MonoBehaviour
{
    private string adId = "3467018";
    private string bannerAd = "bottomBanner";
    private static string videoAd = "video";
    bool showingBannerAd = false;
    // Start is called before the first frame update
    void Start()
    {
        // Advertisement.Initialize(adId, true);
        

    }

    // Update is called once per frame
    public static void showVideoAd()
    {
        if (Advertisement.IsReady(videoAd))
        {
            Advertisement.Show(videoAd);

        }
    }

    void Update(){
        // if (PlayGameScene.blastOffTriggered && !showingBannerAd && !RocketPig.die){
        //     Debug.Log("showing banner ad");
        //     showingBannerAd =true;
        // }
        // if (RocketPig.die){
        //     showingBannerAd=false;
        //     Advertisement.Banner.Hide();
        // }
        // if (SceneManager.GetActiveScene().name=="Main menu" && PreloadScript.isFirstLoadMainMenu){
        //     showingBannerAd=false;
        //     Advertisement.Banner.Hide();
        //     Debug.Log("main menu hide banner ad");

        // }else if (!showingBannerAd){
        //     StartCoroutine(ShowBannerWhenReady());
        //     showingBannerAd =true;

        // }
        // if (!PlayGameScene.blastOffTriggered){
        //     showingBannerAd=false;
        //     Advertisement.Banner.Hide();
        // }
    

    }
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerAd))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);
    }
}
