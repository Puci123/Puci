using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ręka : MonoBehaviour {

    private Transform renka;
   // public GameObject[] karty;


    private void Start()
    {
        renka = GetComponent<Transform>();
        
    }
    public void DobierzStart(Karta karta)
    {
         karta.GetComponent<Transform>().parent = renka.transform;
        //karta.GetComponent<Transform>().SetParent(renka.transform);
    }
   
   

}
