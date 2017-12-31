using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idz : KartaZeSiatka {



    public void Przejdz(Vector3 meta)
    {
		GeratorMapy gm = Camera.main.GetComponent<GeratorMapy> ();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().
        UaktualnijPozycję(gm.Znajdz(GeratorMapy.pole.gracz), gm.Znajdz(meta));
       // gracz.GetComponent<NavMeshAgent>().updateRotation = false;
        gracz.GetComponent<NavMeshAgent>().destination = meta;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    

    override
        public void CzaryMary()
    {
        Zmienne.wyswietlam = true;
        Generuj(transform);

    }

    override
        public void Zniszcz()
    {
        Schowaj();
    }
}
