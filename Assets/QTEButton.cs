using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEButton : MonoBehaviour
{
    public float _fillingTime;
    public Image _ringImage;
    private bool keyPressed = false;
    private bool buttonDisplayed = true;
    private bool _active = false; 

    public Animator bulloAnim;
    public Animator padre;
    public float _currTime = 0f; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if( _active )
        {
            if( _currTime <= _fillingTime && !keyPressed )
            {
                float fillingValue = _currTime / _fillingTime;
                _ringImage.fillAmount = fillingValue;
                _currTime += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keyPressed = true;

                    //transizione in uscita button
                    LeanTween.scale(transform.gameObject, new Vector3(0f, 0f, 0f), 1f).setDelay(.3f).setEase(LeanTweenType.easeInOutElastic);

                    //QTE Success
                    Debug.Log("Success");
                    bulloAnim.SetTrigger("QTEsuccess");
                    padre.SetTrigger("QTEsuccess");
                    _active = false; 

                }
            }
            else if( !keyPressed && buttonDisplayed)
            {
                _ringImage.fillAmount = 1f;

                //transizione in uscita button
                buttonDisplayed = false;
                _active = false; 
                LeanTween.scale(transform.gameObject, new Vector3(0f, 0f, 0f), 1f).setDelay(.3f).setEase(LeanTweenType.easeInOutElastic);
                Debug.Log("Failed: timeout!");
                bulloAnim.SetTrigger("QTEfail");
                padre.SetTrigger("QTEfail");
            }
        }
        
    }

    public void Active()
    {
        _active = true;
        buttonDisplayed = true;
        keyPressed = false;
        _currTime = 0f; 
        LeanTween.scale(transform.gameObject, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeInOutCirc);
    }
}
