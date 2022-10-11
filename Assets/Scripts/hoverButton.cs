using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hoverButton : MonoBehaviour
{

    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;
    public Button btn;
    public Button btn2;

    public GameObject choice0;
    public GameObject choice1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor1(){

         if(PauseMenu.GameIsPaused){
            return;
         }

        textmeshPro.color = new Color32(231, 231, 231, 255);
        textmeshPro2.color = new Color32(231, 231, 231, 50);
        btn.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
        btn2.GetComponent<Image>().color = new Color32(0, 0, 0, 50);
    }

    public void ChangeColor2(){

         if(PauseMenu.GameIsPaused){
            return;
         }

        textmeshPro.color = new Color32(231, 231, 231, 50);
        textmeshPro2.color = new Color32(231, 231, 231, 255);
        btn.GetComponent<Image>().color = new Color32(0, 0, 0, 50);
        btn2.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
    }
}
