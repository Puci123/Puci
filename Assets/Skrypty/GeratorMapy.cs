using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeratorMapy : MonoBehaviour {

	public bool mapaWygerowana = false;
	public int rozmiarX, rozmiarY;
	public int graczX, graczY;
    public Transform komorka;
    public Transform rodzic;
	public enum pole{wolne,zajete,wrog,gracz};
	public Mapa[,] map;

	public class Mapa{

		public pole _pole;
		public Vector3 pos;

		public Mapa(pole p,Vector3 _pos){
			_pole = p;
			pos = _pos;
		}
	}

	void Start () {
        Generuj();
	}

    void Generuj()
    {
		map = new Mapa[rozmiarX, rozmiarY];

        Vector3 pos = Vector3.zero;

		for (int i = 0; i < rozmiarY; i++)
        {
			for (int j = 0; j < rozmiarX; j++)
            {
				var temp = Instantiate (komorka, pos, Quaternion.identity);
				temp.SetParent(rodzic);
				map [i, j] = new Mapa (pole.wolne, pos);
                pos.x += komorka.transform.lossyScale.x;
            }
            pos.z += komorka.transform.lossyScale.y;
            pos.x = pos.x - 9;
        }
		GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().PojawGracza(map[graczX,graczY].pos);
		map [graczX, graczY]._pole = pole.gracz;
		mapaWygerowana = true;

    }

	public Mapa Poszukaj(pole szukane){
		foreach (var item in map) {
			if (item._pole == szukane) {
				return item;
			}
		}
		return null;

	}

	public Mapa PoszukajPoPozycji(Vector3 pos){
		foreach (var item in map) {
			if (item.pos.x == pos.x && item.pos.z == item.pos.z) {
					print (item.pos);
					return item;
				}
			}
			return null;
		}
		
	}


