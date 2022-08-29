using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cabinet : MonoBehaviour
{
    public bool isOpen = false; 
    public GameObject anta_dx;
    public GameObject anta_sx; 

    public void OpenDoors()
    {
        anta_dx.transform.DORotate(new Vector3(0, -160, 0), 2);
        anta_sx.transform.DORotate(new Vector3(0, 90, 0), 2);
        isOpen = true; 
    }

    public void CloseDoors()
    {
        anta_dx.transform.DORotate(new Vector3(0, 0, 0), 2);
        anta_sx.transform.DORotate(new Vector3(0, 0, 0), 2);
        isOpen = false; 
    }
}