using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciagnij : MonoBehaviour {

    protected GameObject rzecz;
    protected RectTransform rt;
    protected Vector2 startPos;
    protected bool przeciagany = false;
    

    public void PowrocNaStart()
    {
        GetComponent<Transform>().parent = GameObject.Find("Image").GetComponent<Transform>();
    }

    public void Przeciagany()
    {
        przeciagany = true;
        transform.parent = GameObject.Find("Canvas").GetComponent<Transform>();

    }
    public void Upuszczony()
    {
        przeciagany = false;
        print(transform.parent);


        Vector2 aPos = rt.anchoredPosition;
        float minOdleglosc = 99999.0f;
        GameObject[] lista = GameObject.FindGameObjectsWithTag("Drop");

        foreach (GameObject item in lista)
        {
            float x = item.GetComponent<RectTransform>().anchoredPosition.x;
            float y = item.GetComponent<RectTransform>().anchoredPosition.y;

            float odleglosc = Mathf.Sqrt(Mathf.Pow(x - aPos.x, 2) + Mathf.Pow(y - aPos.y, 2));
            if(minOdleglosc > odleglosc)
            {
                minOdleglosc = odleglosc;
                rzecz = item;
            }  
        }

        if (minOdleglosc <= 100f)
        {
            print("Jestem tu");
            rzecz.GetComponent<Upusc>().Dodaj(gameObject.GetComponent<Przeciagnij>());
        }
        else
            GetComponent<Transform>().parent = GameObject.Find("Image").GetComponent<Transform>();

    }

}
