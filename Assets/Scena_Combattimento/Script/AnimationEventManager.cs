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
    public Transform fountainWater;
    public ParticleSystem pSystem_1_dad;
    public ParticleSystem pSystem_2_dad;
    public ParticleSystem pSystem_1_ragazzino;
    public ParticleSystem pSystem_2_ragazzino;
    public ParticleSystem pSystem_fountain;
    //public AudioManager audioMgr;
    public Transform fountain;


    public void PunchReact()
    {
        _bullo.SetTrigger("PunchReacting");
        //audioMgr.Play("punch_1");
    }

    public void Punch()
    {
        ragazzino.GetComponent<Animator>().SetTrigger("Cadi");
        //audioMgr.Play("punch_1");
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
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_1");
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
        GameObject.FindGameObjectWithTag("Spazzatura_1").transform.position = rightHandBone.position;
        GameObject.FindGameObjectWithTag("Spazzatura_1").transform.SetParent(rightHandBone);
    }
    public void ParentLattina_2()
    {
        GameObject.FindGameObjectWithTag("Spazzatura_2").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Spazzatura_2").transform.position = rightHandBone.position;
        GameObject.FindGameObjectWithTag("Spazzatura_2").transform.SetParent(rightHandBone);
    }
    public void ParentLattina_3()
    {
        GameObject.FindGameObjectWithTag("Spazzatura_3").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Spazzatura_3").transform.position = rightHandBone.position;
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
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("squirrel_1");
    }

    public void CloseFountain()
    {
        AudioSource audioSrc = fountain.GetComponent<AudioSource>();
        ParticleSystem pSystem = fountainWater.gameObject.GetComponent<ParticleSystem>();
        if( pSystem.isPlaying )
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("chiudi_fontana");
            audioSrc.Stop();
            pSystem_fountain.Stop();
            pSystem.Stop();
        }
        else if ( pSystem.isStopped )
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("chiudi_fontana");
            audioSrc.Play();
            pSystem.Play();
            pSystem_fountain.Play();
        }
    }

    public void PlayParticleSystemDad()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_2");
        pSystem_1_dad.gameObject.SetActive(true);
        pSystem_2_dad.gameObject.SetActive(true);
        pSystem_2_dad.Play();
        pSystem_1_dad.Play();
    }

    public void PlayParticleSystemRagazzino()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_1");
        pSystem_1_ragazzino.gameObject.SetActive(true);
        pSystem_2_ragazzino.gameObject.SetActive(true);
        pSystem_2_ragazzino.Play();
        pSystem_1_ragazzino.Play();
    }

    public void PunchSoundOne()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_1");
    }

    public void PunchSoundTwo()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_2");
    }

    public void PunchSoundThree()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_3");
    }

    public void SchivataSound()
    {
        //audioMgr.Play();
    }

    public void StartCombattimento()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("combattimento");
    }

    public void EndCombattimento()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("combattimento");
    }

    public void RagazzinoReaction()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("punch_2");
    }
}
