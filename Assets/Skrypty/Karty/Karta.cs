using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karta : Przeciagnij {

    public int koszt = 1;
    public bool toJestKartaRuchu;

     public virtual void CzaryMary()
    {
        print("Czary Mary");
        
    }

    public virtual void Zniszcz()
    {
        print("Nisczę");
    }

}
