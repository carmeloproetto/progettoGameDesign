using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationEventManager : MonoBehaviour
{
    public Animator _bullo;
    public Animator ragazzino;
    public Animator dad;
    public Transform rightHandIK;
    public Transform rightHandBone; 
    public Rig rig;
    public Transform acorn;
    public Transform squirrel;


    public void PunchReact()
    {
        _bullo.SetTrigger("PunchReacting");
    }

    public void Punch()
    {
        ragazzino.GetComponent<Animator>().SetTrigger("Cadi");
    }


    //funzione che parte quando il bambino è per terra
    void dadWalks(){
        dad.GetComponent<followDestination6>().enabled = true;
    }

    public void StartDadReaction()
    {
        dad.SetTrigger("startReaction");
    }

    public void StartBullyReaction()
    {
        _bullo.SetTrigger("startReaction");
    }

    public void SpingiBullo()
    {
        _bullo.SetTrigger("cadi");
    }

    public void RaccogliLattina(Transform lattina)
    {
        rightHandIK.position = lattina.position;
    }

    public void AzzeraWeight()
    {
        StartCoroutine(SmoothRig(rig, 1f, 0f));
        Debug.Log("Azzero weight");
    }

    public void SettaWeight()
    {
        StartCoroutine(SmoothRig(rig, 0f, 1f));
        Debug.Log("Setto weight");

    }

    public void ParentLattina_1()
    {
        GameObject.FindGameObjectWithTag("Spazzatura_1").GetComponent<Rigidbody>().isKinematic = true; 
        GameObject.FindGameObjectWithTag("Spazzatura_1").transform.SetParent(rightHandBone);
    }
    public void ParentLattina_2()
    {
        GameObject.FindGameObjectWithTag("Spazzatura_2").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Spazzatura_2").transform.SetParent(rightHandBone);
    }
    public void ParentLattina_3()
    {
        GameObject.FindGameObjectWithTag("Spazzatura_3").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Spazzatura_3").transform.SetParent(rightHandBone);
    }

    public void DeleteLattina(int number)
    {
        if( number == 1)
        {
            GameObject.FindGameObjectWithTag("Spazzatura_1").transform.LeanScale(new Vector3(0f, 0f, 0f), 1f).setDestroyOnComplete(true);
        }
        else if( number == 2)
        {
            GameObject.FindGameObjectWithTag("Spazzatura_2").transform.LeanScale(new Vector3(0f, 0f, 0f), 1f).setDestroyOnComplete(true);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spazzatura_3").transform.LeanScale(new Vector3(0f, 0f, 0f), 1f).setDestroyOnComplete(true);
        }

    }

    IEnumerator SmoothRig(Rig rig, float start, float end)

    {

        float elapsedTime = 0;
        float waitTime = 0.5f;



        while (elapsedTime < waitTime)
        {
            rig.weight = Mathf.Lerp(start, end, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    public void AcornOn()
    {
        this.acorn.gameObject.SetActive(true);
    }

    public void AcornOff()
    {
        this.acorn.gameObject.SetActive(false);
    }

    public void SquirrelJump()
    {
        squirrel.gameObject.GetComponent<Animator>().SetTrigger("Jump");
    }

    public void CloseFountain()
    {
        Debug.Log("Fountain closed!");
    }
}
