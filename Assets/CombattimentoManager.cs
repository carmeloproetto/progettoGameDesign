using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombattimentoManager : MonoBehaviour
{
    public QTEButton qte_1;
    public QTEButton qte_2;
    public QTEButton qte_3;
    public QTEButton qte_4;
    public QTEButton qte_5;

    public QTEButton qteGarbage_1;
    public QTEButton qteGarbage_2;
    public QTEButton qteGarbage_3;

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
        else if( number == 2 )
        {
            qte_2.Active();
        }
        else if( number == 3 )
        {
            qte_3.Active();
        }
        else if (number == 4)
        {
            qte_4.Active();
        }
        else if (number == 5)
        {
            qte_5.Active();
        }
        else if (number == 6)
        {
            qteGarbage_1.Active();
        }
        else if (number == 7)
        {
            qteGarbage_2.Active();
        }
        else if (number == 8)
        {
            qteGarbage_3.Active();
        }
    }
}
