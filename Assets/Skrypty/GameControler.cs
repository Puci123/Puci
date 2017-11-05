using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

    public Text termoetr;
    public int punktyNagrzania;
    public int maxPunktyNagrzania;
    public Upusc upusc;
    public StworzTalie talia;

    private void Start()
    {
        termoetr.text = "" + punktyNagrzania + " / " + maxPunktyNagrzania;
    }

    public void Pas()
    {
        if (!Zmienne.wyswietlam)
        {
            upusc.Usun();
            talia.Dobierz(2);

            if (punktyNagrzania >= 2)
                ZminenNagrzanie(-2);
            else
                ZminenNagrzanie(-punktyNagrzania);
        }
    }

    public void ZminenNagrzanie(int ile)
    {
        punktyNagrzania += ile;
        termoetr.text = "" + punktyNagrzania + " / " + maxPunktyNagrzania;
    }
}
