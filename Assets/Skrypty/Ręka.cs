using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ręka : MonoBehaviour {

    private Transform renka;
    public GameObject[] karty;


    private void Start()
    {
        renka = GetComponent<Transform>();
        Dobierz();
    }


    void Dobierz()
    {
        foreach (var item in karty)
        {
            item.GetComponent<Transform>().parent = renka.transform;
        }  
    }
   
   

}
