using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StworzTalie : MonoBehaviour {

    public Transform tranAtak;
    public Transform tranObrona;
    public Transform tranRuch;
    public Transform tranTalia;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void Stworz()
    {
        Transform temp;

        foreach (var item in Zmienne.talia)
        {
           if(item == Zmienne.Typy.atak)
            {
                temp = tranAtak;
            }
            else if(item == Zmienne.Typy.obrona)
            {
                temp = tranObrona;
            }
            else
            {
                temp = tranRuch;
            }
            Instantiate(temp, tranTalia);
        }
        
    }
}
