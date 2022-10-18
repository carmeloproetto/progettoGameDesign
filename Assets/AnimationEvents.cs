using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationEvents : MonoBehaviour
{
    public Transform gabbiaEmpty;
    public Transform gabbia;
    public Transform porticinaGabbia;
    public Transform gabbiaFloor;
    public Transform gabbiaFloorDoor;
    public Transform paper;
    public Rig rig; 

    public GameObject mom;

    public void LiberaGabbia()
    {
        //_startTransition = true;
        //gabbiaEmpty.transform.parent = null;
        //gabbia.GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(DecreaseRigWeight());
    }

    public void LiberaGabbiaFull()
    {
        //_startTransition = true;
        gabbiaEmpty.transform.parent = null;
        gabbia.GetComponent<Rigidbody>().isKinematic = false;
        porticinaGabbia.GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(DecreaseRigWeight());
    }

    public void PrendiGabbia()
    {
        //gabbiaEmpty.transform.parent = rightArmBone;
        //gabbia.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(IncreaseRigWeight());
    }

    IEnumerator IncreaseRigWeight()
    {
        while( rig.weight < 1f)
        {
            rig.weight += Time.deltaTime * 1.5f;
            yield return null;
        }
    }

    IEnumerator DecreaseRigWeight()
    {
        while (rig.weight > 0f)
        {
            rig.weight -= Time.deltaTime * 1.5f;
            yield return null;
        }
    }

    public void PlaceCageOnTheFloor()
    {
        LiberaGabbia();
        gabbiaEmpty.gameObject.SetActive(false);
        gabbiaFloor.gameObject.SetActive(true);
        gabbiaFloorDoor.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gabbiaFloor.SetParent(null);
    }

    public void PaperOn()
    {
        Debug.Log("Estraggo il foglio");
        paper.gameObject.SetActive(true);
    }

    public void PaperOff()
    {
         Debug.Log("Conservo il foglio");
        paper.gameObject.SetActive(false);
    }


    public void StartCorsa(){
        Debug.Log("Attivo lo script");
        
        mom.GetComponent<followDestinationCap2_3_2>().followDestinationEnabled = true;
    }
}
