using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AfferraGabbia : MonoBehaviour
{
    public Transform gabbiaRagazzino;
    public Transform gabbiaPadre;
    public Rig rig;

    public void AttivaGabbia()
    {
        gabbiaRagazzino.gameObject.SetActive(false);
        gabbiaPadre.gameObject.SetActive(true);
    }

    public void AttivaPeso()
    {
        StartCoroutine(IncreaseRigWeight());
    }

    IEnumerator IncreaseRigWeight()
    {
        while (rig.weight < 1f)
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
}
