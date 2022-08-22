using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected bool interactable = true;

    public abstract bool Interact();

    protected abstract void Start();

    protected abstract void Update();
}
