using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cloud.OnInitializeComplete-=CloudOnceInitializeComplete;
        Cloud.Initialize(false,true);
    }

    // Update is called once per frame
    public void CloudOnceInitializeComplete()
    {
        Debug.LogWarning("Initialize");
    }
    public void ClickScore()
    {
        Debug.LogWarning("adding score to leaderboard");
        
    }
}
