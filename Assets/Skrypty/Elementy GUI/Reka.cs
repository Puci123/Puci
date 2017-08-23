using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reka : MonoBehaviour {

    private Transform reka;


    private void Start()
    {
        reka = GetComponent<Transform>();
        
    }
    public void Dobierz(Karta karta)
    {
         karta.GetComponent<Transform>().parent = reka.transform;
    }
   
   

}
