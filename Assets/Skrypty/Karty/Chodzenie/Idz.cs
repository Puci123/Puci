using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idz : Karta {

    public int sizeX, sizeY;
    public Transform komorka;
    public Transform pusty;

    private Transform wskaznik;
    private Transform rodzic;

    void Generuj()
    {

        wskaznik = GameObject.Find("Wskaznik").GetComponent<Transform>();
        rodzic = Instantiate(pusty);
        Transform temp;

        Vector3 orginal = wskaznik.position;
        orginal.y = 0.61f;

        orginal.x = orginal.x - (sizeX / 2);
        orginal.z = orginal.z- (sizeY / 2);

        for (int j = 0; j  < sizeY; j++)
        {
            for (int i = 0; i < sizeX; i++)
            {
                temp = Instantiate(komorka, orginal, Quaternion.Euler(90, 0, 0));
                temp.SetParent(rodzic);
                temp.GetComponent<Komorka>().Przyjmij(GetComponent<Idz>());
                orginal.x += komorka.localScale.x;
            }
            orginal.x = wskaznik.position.x - (sizeX / 2);
            orginal.z += komorka.localScale.z;
        
        }
       
    }

    public void Schowaj()
    {
        Destroy(rodzic.gameObject);
        Zmienne.wyswietlam = false;

    }

    override
        public void CzaryMary()
    {
        Generuj();
    }

    override
        public void Zniszcz()
    {
        Schowaj();
    }
}
