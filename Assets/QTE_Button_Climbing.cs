using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Button_Climbing : MonoBehaviour
{
    public float _fillingTime;
    public Image _ringImage;
    private bool keyPressed = false;
    private bool buttonDisplayed = true;
    private bool _active = false;

    [SerializeField] public float _currTime = 0f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if (_currTime <= _fillingTime && !keyPressed)
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
                    animator.SetTrigger("QteSuccess");
                    animator.SetBool("FreeFall", false); 
                    _ringImage.CrossFadeColor(Color.green, 2f, true, true);
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("qte_success");
                    _active = false;

                }
            }
            else if (!keyPressed && buttonDisplayed)
            {
                _ringImage.fillAmount = 1f;
                animator.SetTrigger("QteFailed");
                animator.SetBool("FreeFall", false);
                animator.SetBool("isHanging", false);
                animator.gameObject.GetComponentInParent<PadreController_RetroAzienda>().EnableInput();
                animator.gameObject.GetComponentInParent<PadreController_RetroAzienda>().EnableJump();

                //transizione in uscita button
                buttonDisplayed = false;
                _active = false;
                _ringImage.CrossFadeColor(Color.red, 2f, true, true);
                LeanTween.scale(transform.gameObject, new Vector3(0f, 0f, 0f), 1f).setDelay(.3f).setEase(LeanTweenType.easeInOutElastic);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("qte_fail");
                Debug.Log("Failed: timeout!");
            }
        }

    }

    public void Active()
    {
        _active = true;
        buttonDisplayed = true;
        keyPressed = false;
        _currTime = 0f;
        _ringImage.CrossFadeColor(Color.white, 0f, true, true);
        LeanTween.scale(transform.gameObject, new Vector3(0.0048f, 0.0048f, 0.0048f), 1f).setEase(LeanTweenType.easeInOutCirc);
    }
}
