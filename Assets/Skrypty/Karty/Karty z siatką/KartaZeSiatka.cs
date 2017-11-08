using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartaZeSiatka : Karta {

    public int sizeX, sizeY;
    public Transform komorka;
    public Transform pusty;
    public Transform gracz;
    protected Transform rodzic;

    public void Generuj(Transform karta)
    {
        Zmienne.wyswietlam = true;
        GetComponent<Przeciagnij>().siatkaIstneje = true;
        rodzic = Instantiate(pusty);
        gracz = GameObject.FindGameObjectWithTag("Player").transform;
        Transform temp;

        Vector3 orginal = gracz.position;
        orginal.y = 0.61f;

        orginal.x = orginal.x - (sizeX / 2);
        orginal.z = orginal.z - (sizeY / 2);

        for (int j = 0; j < sizeY; j++)
        {
            for (int i = 0; i < sizeX; i++)
            {
                temp = Instantiate(komorka, orginal, Quaternion.Euler(90, 0, 0));
                temp.SetParent(rodzic);
                temp.GetComponent<PodstawowaKomorka>().Przyjmij(karta);
                orginal.x += komorka.localScale.x;
            }
            orginal.x = gracz.position.x - (sizeX / 2);
            orginal.z += komorka.localScale.z;

        }

    }

    public void Schowaj()
    {
        Destroy(rodzic.gameObject);
        Zmienne.wyswietlam = false;
        GetComponent<Przeciagnij>().siatkaIstneje = false;

    }
}
