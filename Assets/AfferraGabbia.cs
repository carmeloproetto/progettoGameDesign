using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AfferraGabbia : MonoBehaviour
{
    public Transform gabbiaRagazzino;
    public Transform gabbiaPadre;
    public Rig rig;
    public Material luciMateriale;
    public Transform car;
    public Transform carDestination;

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

    public void SpingiRagazzo()
    {
        GameObject.FindGameObjectWithTag("Ragazzino").GetComponent<Animator>().SetTrigger("Continue");
    }

    public void AccendiLuci()
    {
        luciMateriale.EnableKeyword("_EMISSION");
    }

    public void CarMovement()
    {
        Vector3 finalPosition = new Vector3(carDestination.position.x, car.position.y, carDestination.position.z);
        car.DOMove(finalPosition, 10f);
        for( int i=0; i < car.childCount; i++) {
            Transform wheel = car.GetChild(i);
            wheel.DORotate(new Vector3(0f, 0f, 360f), 8f);
        }
    }
}
