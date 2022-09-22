using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombattimentoManager : MonoBehaviour
{
    public QTEButton qte_1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveQTE(int number)
    {
        if( number == 1)
        {
            qte_1.Active();
        }
    }
}
