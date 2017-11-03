using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

    public Upusc upusc;
    public StworzTalie talia;

	public void Pas()
    {
        if (!Zmienne.wyswietlam)
        {
            upusc.Usun();
            talia.Dobierz(2);
        }
    }
}
