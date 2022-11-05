using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 1f).setDelay(.4f).setLoopPingPong();
        LeanTween.scale(this.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1f).setDelay(.4f).setLoopPingPong();
    }
}
