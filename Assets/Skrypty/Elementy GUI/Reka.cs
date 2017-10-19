using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reka : MonoBehaviour {

    private Transform reka;


    private void Awake()
    {
        reka = GetComponent<Transform>();    
    }

    public void Dobierz(Transform karta)
    {
        karta.parent = reka.transform;
    }


}
