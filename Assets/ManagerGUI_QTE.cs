using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ManagerGUI_QTE : MonoBehaviour
{
    public GameObject prefabButton;
    private GameObject button; 
    public Canvas canvas;
    public GameObject barile;
    public GameObject _collider;
    public Transform barileTrigger; 

    public void EaseInButton()
    {
        if (button == null)
        {
            button = GameObject.Instantiate(prefabButton, canvas.transform);
            LeanTween.scale(button, new Vector3(1f, 1f, 1f), 1.5f).setDelay(.3f).setEase(LeanTweenType.easeInOutBack);
        }
    }

    public void EaseOutButton()
    {
        _collider.GetComponent<BoxCollider>().enabled = false;
        barileTrigger.GetComponent<BoxCollider>().enabled = true;
        Transform forceOrigin = barile.transform.Find("ForceOrigin");
        barile.GetComponent<Rigidbody>().AddForceAtPosition(forceOrigin.forward * 100f, forceOrigin.position);
        LeanTween.scale(button, new Vector3(0f, 0f, 0f), 1.5f).setDelay(.3f).setEase(LeanTweenType.easeInOutBack);
    }
}
