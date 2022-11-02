using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On()
    {
        LeanTween.scale(this.gameObject, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Off()
    {
        LeanTween.scale(this.gameObject, new Vector3(0f, 0f, 0f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }
}
