using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressInTime : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI DisplayBox;
    public TMPro.TextMeshProUGUI PassBox;

    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    
    // Update is called once per frame
    void Update()
    {
        if(WaitingForKey == 0){
            QTEGen = Random.Range(1, 4);
            CountingDown = 1;
            StartCoroutine(CountDown());

            if(QTEGen == 1){
                WaitingForKey = 1;
                DisplayBox.text = "[E]";
            }
            if(QTEGen == 1){
                WaitingForKey = 1;
                DisplayBox.text = "[R]";
            }
            if(QTEGen == 1){
                WaitingForKey = 1;
                DisplayBox.text = "[T]";
            }
        }

        if(QTEGen == 1){
            if(Input.anyKeyDown){
                if(Input.GetKey(KeyCode.E)){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if(QTEGen == 2){
            if(Input.anyKeyDown){
                if(Input.GetKey(KeyCode.R)){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if(QTEGen == 3){
            if(Input.anyKeyDown){
                if(Input.GetKey(KeyCode.T)){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }


    }



    IEnumerator KeyPressing(){
        QTEGen = 4;
        if(CorrectKey == 1){
            CountingDown = 2;
            PassBox.text = "PASS!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.text = "";
            DisplayBox.text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }

        if(CorrectKey == 2){
            CountingDown = 2;
            PassBox.text = "FAIL!!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.text = "";
            DisplayBox.text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator  CountDown(){
        yield return new WaitForSeconds(3.5f);
        if(CountingDown == 1){
            QTEGen = 4;
            CountingDown = 2;
            PassBox.text = "FAIL!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.text = "";
            DisplayBox.text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;

        }
    }
}
