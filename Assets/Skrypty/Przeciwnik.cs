using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Przeciwnik : MonoBehaviour {

    public int hp = 2;
    public int zasieng;
	public int zasiengWzroku;
    public int zasiengAtaku;
    public Vector3 playerPos;
	private GeratorMapy gMapy;
    private bool wykonanoAkcje = false;
    private Vector3 temp;
    private Vector3[] polaWZasiengu;

	void Awake(){
		gMapy = Camera.main.GetComponent<GeratorMapy> ();
        polaWZasiengu = new Vector3[9];
	}


	public void PryjmijObrażenia(int ile)
    {
        hp -= ile;
		print("Mam " + hp + " PŻ");
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            Zmienne.pToWin--;
        }
    }

    public void RozpocnijTure()
    {
        temp = Patrze(zasiengAtaku);
        if (temp != Vector3.one / 2) {
            Atak();
            wykonanoAkcje = true;
        }
        temp = Patrze(zasiengWzroku);
        if (temp != Vector3.one / 2 && !wykonanoAkcje)
        {
            WidzeGracza(temp);
        }
    }

	public Vector3 Patrze(int _zasieng){
       GeratorMapy.Mapa gracz = gMapy.Znajdz(GeratorMapy.pole.gracz);
        if (gracz != null)
        {
            foreach (var item in gMapy.map)
            {
                if (item.pos.x >= transform.position.x - _zasieng && item.pos.x <= transform.position.x + _zasieng && item.pos.z >= transform.position.z - _zasieng && item.pos.z <= transform.position.z + _zasieng)
                {
                    if (item._pole == GeratorMapy.pole.gracz)
                    {
                        return item.pos;
                    }
                }
            }
        }
        return Vector3.one / 2;
    }

    void WidzeGracza(Vector3 _plyerPos)
    {
        GetComponent<NavMeshAgent>().destination = Skanuj();
    }

    void Atak()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControler>().ZadajObrażenia(3);
    }

    Vector3 Skanuj()
    {
        int i = 0;
        float temp = Mathf.Infinity;
        Vector3 najblizej = Vector3.one;
        Vector3 pPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        foreach (var item in gMapy.map)
        {
            if (item.pos.x >= transform.position.x - zasieng && item.pos.x <= transform.position.x + zasieng && item.pos.z >= transform.position.z - zasieng && item.pos.z <= transform.position.z + zasieng)
            {
                polaWZasiengu[i] = item.pos;
                i++;
            }
        }

        foreach (var item in polaWZasiengu)
        {
            float distance = Vector3.Distance(item, pPos);
            if (distance < temp && item.z != transform.position.z && item.x != transform.position.x)
            {
                temp = distance;
                najblizej = item;
            }
        }
        najblizej = new Vector3(Mathf.Round(najblizej.x), Mathf.Round(najblizej.y), Mathf.Round(najblizej.z));
        return najblizej;
    }
}
