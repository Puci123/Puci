using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idz : Karta {

    public int sizeX, sizeY;
    public Transform komorka;
    public Transform pusty;
    public Transform gracz;

    private Transform rodzic;

   



    void Generuj()
    {
        GetComponent<Przeciagnij>().siatkaIstneje = true;
        rodzic = Instantiate(pusty);
        gracz = GameObject.FindGameObjectWithTag("Player").transform;
        Transform temp;

        Vector3 orginal = gracz.position;
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
            orginal.x = gracz.position.x - (sizeX / 2);
            orginal.z += komorka.localScale.z;
        
        }
       
    }

    public void Przejdz(Vector3 meta)
    {
       // gracz.GetComponent<NavMeshAgent>().updateRotation = false;
        gracz.GetComponent<NavMeshAgent>().destination = meta;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void Schowaj()
    {
        Destroy(rodzic.gameObject);
        Zmienne.wyswietlam = false;
        GetComponent<Przeciagnij>().siatkaIstneje = false;

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
