using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected bool interactable = true;
    [SerializeField] protected Sprite icon;
    [SerializeField] protected string text; 

    public abstract bool Interact();

    protected abstract void Start();

    protected abstract void Update();

    public string getText() {
        return text; 
    }

    public Sprite getImageIcon()
    {
        return icon;
    }
}
