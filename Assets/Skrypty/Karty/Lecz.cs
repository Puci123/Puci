using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lecz : Karta {

    public GameControler control;
	
    override
   public void CzaryMary()
    {
        control = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControler>();
        control.WyleczGracza();
        Zmienne.wyswietlam = false;
    }
}
