using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterEpilogoLago : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(DialogueManagerCap2_3.finale == 1 || DialogueManagerCap2_3.finale == 3 ){
            //nascondere Lago_brutto e Bostrico_no
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Lago_brutto");
 
            foreach(GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }

            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag ("Bostrico_no");
 
            foreach(GameObject go in gameObjectArray2)
            {
                go.SetActive(false);
            }

        }
        if(DialogueManagerCap2_3.finale == 2){
            //nascondere Lago_bello e Bostrico_si
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Lago_bello");
 
            foreach(GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }

            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag ("Bostrico_si");
 
            foreach(GameObject go in gameObjectArray2)
            {
                go.SetActive(false);
            }
        }

        if(DialogueManagerCap3_2.finale == 2 || DialogueManagerCap3_2.finale == 3 || DialogueManagerCap3_2.finale == 5){
            //nascondere Estinzione_si
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Estinzione_si");
 
            foreach(GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }

        }
        
        if(DialogueManagerCap3_2.finale == 1 || DialogueManagerCap3_2.finale == 4){
            //nascondere Estinzione_no
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Estinzione_no");
 
            foreach(GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }

        }


    }

}
