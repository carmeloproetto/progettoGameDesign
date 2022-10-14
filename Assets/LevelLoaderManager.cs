using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderManager : MonoBehaviour
{
    public LevelLoaderScript levelLoader;

    public void NextScene()
    {
        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
    }

    public void NextSceneWithTimer(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
    }


}
