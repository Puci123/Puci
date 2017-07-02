using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	
	void Start () {

        Karta karta;
        karta = GetComponent<Atak>();
        karta.CzaryMary();
        karta = GetComponent<Obrona>();
        karta.CzaryMary();
    }

   
    void Update () {
		
	}
}
