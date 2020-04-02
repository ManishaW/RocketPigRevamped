using UnityEngine;

public class  PreloadScript : MonoBehaviour
{
    public static int countRetryTimes;
    public static bool isFirstLoadMainMenu;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("Before scene loaded");
        PlayerPrefs.SetInt("muteSfx", 0);
		PlayerPrefs.SetInt("muteBgMusic", 0);
        countRetryTimes=0;
        isFirstLoadMainMenu=true;
    }
}