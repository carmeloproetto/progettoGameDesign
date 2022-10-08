using System.Collections;
using UnityEngine;

public class SosBlinkingLight : InteractableObject
{
    public float totalSeconds;
    public float maxIntensity;
    public Light myLight;
    public bool isOn = false;
    private AudioSource audioSource;
    public GameObject _enemy;
    public GameObject trigger; 

    public IEnumerator Blink()
    {
        float waitTime = totalSeconds / 2;

        while(myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;
            yield return null; 
        }

        while(myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;
            yield return null; 
        }
        StartCoroutine(Blink());
        yield return null; 
    }

    public override bool Interact()
    {
        if( !isOn && interactable )
        {
            Debug.Log("Interacting with SOS button");
            trigger.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false; 
            //interactable = false; //non potrò interagire di nuovo
            myLight.enabled = true; //abilito la luce
            audioSource.Play();

            _enemy.GetComponent<Animator>().SetBool("isLooking", false);

            isOn = true;
            StartCoroutine(Blink());
            return true; 
        }
        return false; 
    }

    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        
    }
}
