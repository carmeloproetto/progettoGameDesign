using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractionTrigger : MonoBehaviour
{
    public PlantInteraction plant; 
    
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        plant.setInteractable(true);
    }

    void OnTriggerExit(Collider other)
    {
        plant.setInteractable(false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
