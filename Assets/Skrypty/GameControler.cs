using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

    public int hp;
    public int maxHp;
    public int punktyNagrzania;
    public int maxPunktyNagrzania;
    public Text termoetr;
    public Text hpText;
    public Transform gui;
    public Transform gameOverC;
    public Upusc upusc;
    public StworzTalie talia;

    private void Start()
    {
        termoetr.text = "" + punktyNagrzania + " / " + maxPunktyNagrzania;
        hpText.text = "HP " + hp + " / " + maxHp;

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

        if (punktyNagrzania > maxPunktyNagrzania)
            KoniecGry();
        
    }

    public void WyleczGracza()
    {
        if (hp < maxHp)
            hp++;
        hpText.text = "HP " + hp + " / " + maxHp;
    }

    void KoniecGry()
    {
        gui.gameObject.SetActive(false);
        gameOverC.gameObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
