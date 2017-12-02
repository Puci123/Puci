using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik : MonoBehaviour {

    public int hp = 2;
	public int zasiengWzroku;
	public Transform player;
	private GeratorMapy gMapy;
	private bool spojrzalem = false;

	void Awake(){
		gMapy = Camera.main.GetComponent<GeratorMapy> ();
	}

	void Update(){
		if (Zmienne.turaPrzeciwnika && !spojrzalem)
			Patrze ();
	}

	public void PryjmijObrażenia(int ile)
    {
        hp -= ile;
		print("Mam " + hp + " PŻ");
        if (hp <= 0)
            Destroy(this.gameObject);
    }

	public void Patrze(){
		GeratorMapy.Mapa gracz = gMapy.Poszukaj (GeratorMapy.pole.gracz);
		if (gracz != null)
			print (gracz.pos);
		spojrzalem = true;
	}
}
