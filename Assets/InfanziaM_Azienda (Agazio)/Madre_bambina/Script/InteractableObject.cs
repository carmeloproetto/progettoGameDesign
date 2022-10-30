using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] public bool interactable = true;
    [SerializeField] protected Sprite icon;
    [SerializeField] protected string italian_text;
    [SerializeField] protected string english_text;

    public abstract bool Interact();

    protected abstract void Start();

    protected abstract void Update();

    public virtual string GetText(int languageSetting)
    {
        if( languageSetting == 1)
        {
            return italian_text; 
        }
        else
        {
            return english_text; 
        }
    }

    public Sprite getImageIcon()
    {
        return icon;
    }
}
