using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : KartaZeSiatka {

    Transform player;

    override
    public void CzaryMary()
    {
        Generuj(GetComponent<Transform>());
     
    }
}
