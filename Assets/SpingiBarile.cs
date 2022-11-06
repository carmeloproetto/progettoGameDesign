using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpingiBarile : MonoBehaviour
{
    public GameObject barile;
    private Rigidbody _rigidBody; 
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = barile.GetComponent<Rigidbody>();
        StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("crowd", 1, 0.02f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        _rigidBody.AddForce(new Vector3(0f, 0f, 1000f));
    }
}
