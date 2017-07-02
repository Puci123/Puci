using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ręka : MonoBehaviour {

    private bool  parzyste = true;
    private int ile = 0;
    public RectTransform rt;
    private Vector2 pos;


	void Start () {
        pos = rt.anchoredPosition;
	}
	
	void Update () {
		
	}

    void Dobierz(Karta karta)
    {
        if (parzyste)
        {
             karta.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x + 0.5f,pos.y);
        }
        else
        {
            karta.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x - 0.5f,pos.y);
        }
        parzyste = !parzyste;
        
    }
}
