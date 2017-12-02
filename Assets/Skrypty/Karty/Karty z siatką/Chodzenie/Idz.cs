using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idz : KartaZeSiatka {



    public void Przejdz(Vector3 meta)
    {
		GeratorMapy gm = Camera.main.GetComponent<GeratorMapy> ();
       // gracz.GetComponent<NavMeshAgent>().updateRotation = false;
        gracz.GetComponent<NavMeshAgent>().destination = meta;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().UaktualnijPozycję(gm.Poszukaj(GeratorMapy.pole.gracz),gm.PoszukajPoPozycji(meta));
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
