using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FillingUpQTE : MonoBehaviour
{
    public float fillAmount = 0f;
    public float force = 0f; 
    public float timeThreshold = 0f;
    private bool ringFilled = false;
    public ManagerGUI_QTE manager;
    private PadreController_RetroAzienda _player; 

    // Start is called before the first frame update
    void Start()
    {
        
        manager = GameObject.FindObjectOfType<ManagerGUI_QTE>();
        _player = GameObject.FindObjectOfType<PadreController_RetroAzienda>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !ringFilled )
        {
            Debug.Log("Pressed E button");
            fillAmount += .1f; 
        }

        if( !ringFilled )
        {
            timeThreshold += Time.deltaTime;

            if( timeThreshold > .1f)
            {
                timeThreshold = 0f;
                fillAmount -= .02f;
            }

            if( fillAmount > 1f)
            {
                fillAmount = 1f;
                timeThreshold = 0f; 
                ringFilled = true;
                _player.GetComponent<Animator>().SetBool("isPushing", false);
                manager.EaseOutButton();
                GetComponent<Image>().CrossFadeColor(Color.green, 2f, true, true);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("qte_success");
                Debug.Log("Success!");
            }
            else if( fillAmount < 0f)
            {
                fillAmount = 0f; 
            }

            GetComponent<Image>().fillAmount = fillAmount;
        }
           
    }
}
